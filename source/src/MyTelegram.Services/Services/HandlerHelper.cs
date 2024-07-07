﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Logging;
using MyTelegram.Schema;

namespace MyTelegram.Services.Services;

public class HandlerHelper(
    IServiceProvider serviceProvider,
    ILogger<HandlerHelper> logger)
    : IHandlerHelper
{
    private static readonly ConcurrentDictionary<uint, IObjectHandler> Handlers = new();

    //private readonly static ConcurrentDictionary<uint, IObjectHandler> ExternalHandlers = new();
    public static readonly ConcurrentDictionary<uint, string> AllHandlers = new();
    public static readonly ConcurrentDictionary<uint, string> HandlerShortNames = new();

    private static readonly ConcurrentDictionary<uint, Type> HandlerTypes = new();
    private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);

    private bool _isInitOk;
    private bool _isLoadingHandlers;

    public bool TryGetHandlerShortName(uint objectId,
        [NotNullWhen(true)] out string? handlerShortName)
    {
        return HandlerShortNames.TryGetValue(objectId, out handlerShortName);
    }
    public string GetHandlerFullName(IObject requestData)
    {
        if (requestData is IHasSubQuery subQuery)
        {
            if (subQuery.Query is IHasSubQuery subQuery2)
            {
                if (subQuery2.Query is IHasSubQuery subQuery3)
                {
                    return
                        $"{GetName(requestData)}->{GetName(subQuery.Query)}->{GetName(subQuery2.Query)}->{GetName(subQuery3.Query)}";
                }
                return
                    $"{GetName(requestData)}->{GetName(subQuery.Query)}->{GetName(subQuery2.Query)}";
            }
            return
                $"{GetName(requestData)}->{GetName(subQuery.Query)}";
        }
        return requestData.GetType().Name;
    }
    private string GetName(IObject requestData)
    {
        const int removeCount = 7;// "Request".Length
        return RemovePrefix(requestData.GetType().Name, removeCount);
    }

    public bool TryGetHandlerName(uint objectId,
        [NotNullWhen(true)] out string? handlerName)
    {
        return AllHandlers.TryGetValue(objectId, out handlerName);
    }

    public bool TryGetHandler(uint objectId,
        [NotNullWhen(true)] out IObjectHandler? handler)
    {
        var isInitOk = _isInitOk;
        if (!isInitOk)
        {
            _semaphoreSlim.Wait();
        }

        if (Handlers.TryGetValue(objectId, out handler))
        {
            if (!isInitOk)
            {
                _semaphoreSlim.Release();
            }

            return true;
        }

        if (!isInitOk)
        {
            _semaphoreSlim.Release();
        }

        AllHandlers.TryGetValue(objectId, out var typeName);
        logger.LogWarning("****************** Unsupported request,objectId={ObjectId:x2},handler={Handler}",
            objectId,
            typeName
        );
        throw new NotImplementedException();
    }

    public void InitAllHandlers(Assembly assembly, int totalHandlersCount = 0)
    {
        if (_isLoadingHandlers || _isInitOk)
        {
            return;
        }

        _isLoadingHandlers = true;
        _semaphoreSlim.Wait();

        var sw = Stopwatch.StartNew();

        var baseType = typeof(IObjectHandler);
        var baseInterface = baseType;

        var types = assembly.DefinedTypes
            .Where(p => baseType.IsAssignableFrom(p) && !p.IsAbstract)
            .OrderBy(p => p.Namespace)
            .ThenBy(p => p.Name)
            .ToList();

        var allHandlers = assembly.DefinedTypes
            .Where(p => baseType.IsAssignableFrom(p) && !p.IsAbstract)
            .OrderBy(p => p.Namespace)
            .ThenBy(p => p.Name)
            .ToList();

        foreach (var typeInfo in allHandlers)
        {
            var args = typeInfo.BaseType?.GetGenericArguments();
            if (args?.Length == 2)
            {
                var attr = args[0].GetCustomAttribute<TlObjectAttribute>();
                if (attr != null)
                {
                    AllHandlers.TryAdd(attr.ConstructorId, $"{typeInfo.Namespace}.{typeInfo.Name}");
                    HandlerShortNames.TryAdd(attr.ConstructorId, $"{typeInfo.Name}");

                    //sb.AppendLine($"{{ 0x{attr.ConstructorId:x2},\"{typeInfo.Name}\" }},");
                }
            }
        }

        //#if DEBUG
        //        var sortedHandlers = allHandlers.OrderBy(p => p.Name).ToList();
        //        var sb = new System.Text.StringBuilder();
        //        foreach (var sortedHandler in sortedHandlers)
        //        {
        //            var args = sortedHandler.BaseType?.GetGenericArguments();
        //            if (args?.Length == 2)
        //            {
        //                var attr = args[0].GetCustomAttribute<TlObjectAttribute>();
        //                if (attr != null)
        //                {
        //                    sb.AppendLine($"{{ 0x{attr.ConstructorId:x2},\"{sortedHandler.Name}\" }},");
        //                }
        //            }
        //        }
        //        Console.WriteLine(sb);
        //#endif

        //Console.WriteLine(sb);
        logger.LogInformation("All handlers count:{AllHandlersCount}", AllHandlers.Count);

        foreach (var typeInfo in types)
        {
            var args = typeInfo.BaseType?.GetGenericArguments();
            if (args?.Length == 2)
            {
                var attr = args[0].GetCustomAttribute<TlObjectAttribute>();
                if (attr != null)
                {
                    if (baseInterface.IsAssignableFrom(typeInfo))
                    {
                        var handler = serviceProvider.GetService(typeInfo);

                        if (handler != null)
                        {
                            AddHandler(attr.ConstructorId, (IObjectHandler)handler);
                        }
                        else
                        {
                            logger.LogWarning("Can not find service for Handler {Name}", typeInfo.FullName);
                        }

                        logger.LogInformation("Create handler:{Name}", typeInfo.FullName);
                        HandlerTypes.TryAdd(attr.ConstructorId, typeInfo);
                    }
                }
            }
        }

        sw.Stop();

        logger.LogInformation(
            "Init handlers ok.Elapsed={Elapsed} count={TotalHandlerCount}/{totalCount} ({Percentage})%",
            sw.Elapsed,
            Handlers.Count,
            types.Count,
            Math.Round(Handlers.Count * 100d / types.Count, 2)
        );
        _semaphoreSlim.Release();
        _isInitOk = true;
        _isLoadingHandlers = false;
    }

    private static void AddHandler(uint objectId,
        IObjectHandler handler)
    {
        if (!Handlers.ContainsKey(objectId))
        {
            Handlers.TryAdd(objectId, handler);
        }
    }
    private static string RemovePrefix(string text, int removeCount)
    {
        if (text.Length > removeCount)
        {
            return text[removeCount..];
        }
        return text;
    }
}