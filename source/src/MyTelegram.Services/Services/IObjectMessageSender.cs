﻿using MyTelegram.Schema;

namespace MyTelegram.Services.Services;

public interface IObjectMessageSender
{
    Task PushMessageToPeerAsync<TData>(Peer peer,
        TData data,
        long? excludeAuthKeyId = null,
        long? excludeUserId = null,
        long? onlySendToUserId = null,
        long? onlySendToThisAuthKeyId = null,
        int pts = 0,
        int? qts = null,
        long globalSeqNo = 0,
        LayeredData<TData>? layeredData = null,
        PushData? pushData = null
        ) where TData : IObject;

    Task PushMessageToPeerAsync<TData, TExtraData>(Peer peer,
        TData data,
        long? excludeAuthKeyId = null,
        long? excludeUserId = null,
        long? onlySendToUserId = null,
        long? onlySendToThisAuthKeyId = null,
        int pts = 0,
        int? qts = null,
        long globalSeqNo = 0,
        LayeredData<TData>? layeredData = null,
        TExtraData? extraData = default,
        PushData? pushData = null
        ) where TData : IObject;

    Task PushSessionMessageToAuthKeyIdAsync<TData>(long authKeyId,
        TData data,
        int pts = 0,
        int? qts = null,
        long globalSeqNo = 0,
        LayeredData<TData>? layeredData = null
    ) where TData : IObject;

    ///// <summary>
    /////     Push message to peer,receive server is session server(send from session server)
    ///// </summary>
    ///// <returns></returns>
    //Task PushSessionMessageToPeerAsync<TData>(Peer peer,
    //    TData data,
    //    long? excludeAuthKeyId = null,
    //    long? excludeUserId = null,
    //    long? onlySendToUserId = null,
    //    long? onlySendToThisAuthKeyId = null,
    //    int pts = 0,
    //    int? qts = null,
    //    long globalSeqNo = 0, LayeredData<TData>? layeredData = null) where TData : IObject;

    Task SendFileDataToPeerAsync<TData>(/*long reqMsgId,*/
        RequestInfo requestInfo,
        TData data) where TData : IObject;

    Task SendMessageToPeerAsync<TData>(/*long reqMsgId,*/
        RequestInfo requestInfo,
        TData data) where TData : IObject;

    Task SendRpcMessageToClientAsync<TData>(
        //long reqMsgId,
        RequestInfo requestInfo,
        TData data,
        int pts = 0) where TData : IObject;

    Task SendRpcMessageToClientAsync<TData>(
        long reqMsgId,
        TData data,
        int pts = 0, long permAuthKeyId = 0) where TData : IObject;

    Task SendRpcMessageToClientAsync<TData>(
        //long reqMsgId,
        RequestInfo requestInfo,
        TData data,
        long authKeyId,
        long permAuthKeyId,
        long userId,
        int pts = 0) where TData : IObject;
}