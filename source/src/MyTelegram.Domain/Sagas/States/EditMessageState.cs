﻿namespace MyTelegram.Domain.Sagas.States;

public class EditMessageState : AggregateState<EditMessageSaga, EditMessageSagaId, EditMessageState>,
        IApply<EditOutboxMessageStartedSagaEvent>,
        IApply<OutboxMessageEditCompletedSagaEvent>,
        IApply<InboxMessageEditCompletedSagaEvent>,
        IApply<EditInboxMessageStartedSagaEvent>
{
    public Dictionary<long, int> UidToMessageId = new();
    public Dictionary<long, int> UidToPts = new();

    public int CurrentInboxCount { get; private set; }
    public int EditDate { get; private set; }
    public byte[]? Entities { get; private set; }
    public int InboxCount { get; private set; }

    public bool IsCompleted => InboxCount == CurrentInboxCount;
    public byte[]? Media { get; private set; }
    public byte[]? ReplyMarkup { get; private set; }
#pragma warning disable CS8618
    public string NewMessage { get; private set; }
#pragma warning restore CS8618

    public RequestInfo RequestInfo { get; private set; } = default!;
    public int SenderMessageId { get; private set; }
    public MessageItem OldMessageItem { get; private set; } = default!;
    public void Apply(EditInboxMessageStartedSagaEvent aggregateEvent)
    {
        UidToMessageId.TryAdd(aggregateEvent.UserId, aggregateEvent.MessageId);
        CurrentInboxCount++;
    }

    public void Apply(EditOutboxMessageStartedSagaEvent aggregateEvent)
    {
        RequestInfo = aggregateEvent.RequestInfo;
        SenderMessageId = aggregateEvent.MessageId;
        Entities = aggregateEvent.Entities;
        InboxCount = aggregateEvent.InboxCount;
        Media = aggregateEvent.Media;
        OldMessageItem = aggregateEvent.OldMessageItem;
        NewMessage = aggregateEvent.NewMessage;
        EditDate = aggregateEvent.EditDate;
        ReplyMarkup = aggregateEvent.ReplyMarkup;
    }

    public void Apply(InboxMessageEditCompletedSagaEvent aggregateEvent)
    {
    }

    public void Apply(OutboxMessageEditCompletedSagaEvent aggregateEvent)
    {
    }

    public bool TryGetMessageId(long ownerPeerId,
        out int messageId)
    {
        return UidToMessageId.TryGetValue(ownerPeerId, out messageId);
    }
}
