﻿//namespace MyTelegram.Domain.Events.Messaging;

////public class SelfMessageDeletedEvent : RequestAggregateEvent2<MessageAggregate, MessageId>, IHasCorrelationId
////{
////    public SelfMessageDeletedEvent(RequestInfo requestInfo,Guid correlationId) : base(requestInfo)
////    {
////    }

////    
////}

//public class DeleteMessagesStartedEvent : RequestAggregateEvent2<MessageAggregate, MessageId>
//{
//    public DeleteMessagesStartedEvent(
//        RequestInfo requestInfo,
//        long ownerPeerId,
//        bool isOut,
//        long senderPeerId,
//        int senderMessageId,
//        Peer toPeer,
//        IReadOnlyList<int> idList,
//        bool revoke,
//        IReadOnlyList<InboxItem> inboxItems,
//        long? chatCreatorId) : base(requestInfo)
//    {
//        OwnerPeerId = ownerPeerId;
//        IsOut = isOut;
//        SenderPeerId = senderPeerId;
//        SenderMessageId = senderMessageId;
//        ToPeer = toPeer;
//        IdList = idList;
//        Revoke = revoke;
//        InboxItems = inboxItems;
//        ChatCreatorId = chatCreatorId;

//    }

//    public IReadOnlyList<int> IdList { get; }
//    public IReadOnlyList<InboxItem> InboxItems { get; }
//    public long? ChatCreatorId { get; }
//    public bool IsOut { get; }
//    public long OwnerPeerId { get; }
//    public bool Revoke { get; }
//    public int SenderMessageId { get; }
//    public Peer ToPeer { get; }
//    public long SenderPeerId { get; }

//}