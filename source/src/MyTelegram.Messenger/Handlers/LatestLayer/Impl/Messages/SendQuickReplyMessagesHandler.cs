﻿// ReSharper disable All

namespace MyTelegram.Handlers.Messages;

///<summary>
/// See <a href="https://corefork.telegram.org/method/messages.sendQuickReplyMessages" />
///</summary>
internal sealed class SendQuickReplyMessagesHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestSendQuickReplyMessages, MyTelegram.Schema.IUpdates>,
    Messages.ISendQuickReplyMessagesHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestSendQuickReplyMessages obj)
    {
        throw new NotImplementedException();
    }
}
