﻿namespace MyTelegram.Domain.Commands.Messaging;

public class EditOutboxMessageCommand(
    MessageId aggregateId,
    RequestInfo requestInfo,
    int messageId,
    string newMessage,
    TVector<IMessageEntity>? entities,
    int editDate,
    IMessageMedia? media,
    IReplyMarkup? replyMarkup,
    List<long>? chatMembers)
    : RequestCommand2<MessageAggregate, MessageId, IExecutionResult>(aggregateId, requestInfo)
{
    public int MessageId { get; } = messageId;
    public string NewMessage { get; } = newMessage;
    public TVector<IMessageEntity>? Entities { get; } = entities;
    public int EditDate { get; } = editDate;
    public IMessageMedia? Media { get; } = media;
    public IReplyMarkup? ReplyMarkup { get; } = replyMarkup;
    public List<long>? ChatMembers { get; } = chatMembers;

    protected override IEnumerable<byte[]> GetSourceIdComponents()
    {
        yield return RequestInfo.RequestId.ToByteArray();
    }
}