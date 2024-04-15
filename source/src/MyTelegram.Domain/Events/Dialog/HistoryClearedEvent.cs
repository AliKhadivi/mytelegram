﻿namespace MyTelegram.Domain.Events.Dialog;

public class HistoryClearedEvent : RequestAggregateEvent2<DialogAggregate, DialogId>
{
    public HistoryClearedEvent(
        RequestInfo requestInfo,
        long ownerPeerId,
        int historyMinId,
        bool revoke,
        Peer toPeer,
        string messageActionData,
        long randomId,
        List<int> messageIdListToBeDelete,
        int nextMaxId) : base(requestInfo)
    {
        OwnerPeerId = ownerPeerId;
        HistoryMinId = historyMinId;
        Revoke = revoke;
        ToPeer = toPeer;
        MessageActionData = messageActionData;
        RandomId = randomId;
        MessageIdListToBeDelete = messageIdListToBeDelete;
        NextMaxId = nextMaxId;

    }

    public int HistoryMinId { get; }
    public string MessageActionData { get; }
    public List<int> MessageIdListToBeDelete { get; }
    public int NextMaxId { get; }
    public long OwnerPeerId { get; }
    public long RandomId { get; }
    public bool Revoke { get; }
    public Peer ToPeer { get; }


}
