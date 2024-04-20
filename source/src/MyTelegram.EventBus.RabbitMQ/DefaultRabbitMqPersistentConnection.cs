﻿using Microsoft.Extensions.Options;

namespace MyTelegram.EventBus.RabbitMQ;

public interface IRabbitMqConnectionFactory
{
    IRabbitMqPersistentConnection CreateConnection();
}

public class RabbitMqConnectionFactory(
    IOptions<RabbitMqOptions> options,
    ILogger<DefaultRabbitMqPersistentConnection> logger)
    : IRabbitMqConnectionFactory
{
    public IRabbitMqPersistentConnection CreateConnection()
    {
        return new DefaultRabbitMqPersistentConnection(logger, options);
    }
}

// Original https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/BuildingBlocks/EventBus/EventBusRabbitMQ/DefaultRabbitMQPersistentConnection.cs
public class DefaultRabbitMqPersistentConnection(
    ILogger<DefaultRabbitMqPersistentConnection> logger,
    IOptions<RabbitMqOptions> options)
    : IRabbitMqPersistentConnection
{
    private readonly ILogger<DefaultRabbitMqPersistentConnection> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly int _retryCount = 5;

    private readonly object _syncRoot = new();
    private IConnection? _connection;
    private IConnectionFactory? _connectionFactory;
    private bool _disposed;

    public bool IsConnected => _connection is { IsOpen: true } && !_disposed;

    public IModel CreateModel()
    {
        //if (!IsConnected)
        //{
        //    throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
        //}

        try
        {
            if (_connection != null)
            {
                return _connection.CreateModel();
            }
        }
        catch (TimeoutException)
        {
            Dispose();

            TryConnect();
        }


        if (_connection == null)
        {
            throw new InvalidOperationException(
                "No RabbitMQ connections are available to perform this action,connection is null");
        }

        return _connection.CreateModel();
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _logger.LogInformation("Dispose RabbitMQ connection");
        try
        {
            if (_connection == null)
            {
                return;
            }

            _connection.ConnectionShutdown -= OnConnectionShutdown;
            _connection.CallbackException -= OnCallbackException;
            _connection.ConnectionBlocked -= OnConnectionBlocked;
            _connection.Dispose();
        }
        catch (IOException ex)
        {
            _logger.LogCritical(ex.ToString());
        }
    }

    public bool TryConnect()
    {
        _logger.LogInformation("RabbitMQ Client is trying to connect");

        lock (_syncRoot)
        {
            var policy = Policy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex,
                        time) =>
                    {
                        _logger.LogWarning(ex,
                            "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})",
                            $"{time.TotalSeconds:n1}",
                            ex.Message);
                    }
                );

            policy.Execute(() =>
            {
                _connection = CreateConnectionFactory()
                    .CreateConnection();
                _disposed = false;
            });

            if (IsConnected)
            {
                _connection!.ConnectionShutdown += OnConnectionShutdown;
                _connection.CallbackException += OnCallbackException;
                _connection.ConnectionBlocked += OnConnectionBlocked;

                _logger.LogInformation(
                    "RabbitMQ Client acquired a persistent connection to '{HostName}' and is subscribed to failure events",
                    _connection.Endpoint.HostName);

                return true;
            }

            _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");

            return false;
        }
    }

    private IConnectionFactory CreateConnectionFactory()
    {
        if (_connectionFactory == null)
        {
            var factory = new ConnectionFactory
            {
                HostName = options.Value.HostName,
                Port = options.Value.Port,
                UserName = options.Value.UserName,
                Password = options.Value.Password,
                DispatchConsumersAsync = true,
            };

            _connectionFactory = factory;
        }

        return _connectionFactory;
    }

    private void OnCallbackException(object? sender,
        CallbackExceptionEventArgs e)
    {
        if (_disposed)
        {
            return;
        }

        _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

        TryConnect();
    }

    private void OnConnectionBlocked(object? sender,
        ConnectionBlockedEventArgs e)
    {
        if (_disposed)
        {
            return;
        }

        _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");

        TryConnect();
    }

    private void OnConnectionShutdown(object? sender,
        ShutdownEventArgs reason)
    {
        if (_disposed)
        {
            _logger.LogWarning("A RabbitMQ connection is on shutdown.");
            return;
        }

        _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

        TryConnect();
    }
}
