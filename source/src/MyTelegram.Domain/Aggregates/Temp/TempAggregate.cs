﻿namespace MyTelegram.Domain.Aggregates.Temp;

/// <summary>
/// Add this temp aggregate only for triggering a domain event to start new saga
/// All domain events will not be saved
/// </summary>
/// <param name="id"></param>
public class TempAggregate(TempId id) : AggregateRoot<TempAggregate, TempId>(id), INotSaveAggregateEvents,
    IApply<DeleteMessagesStartedEvent>,
    IApply<DeleteHistoryStartedEvent>,
    IApply<DeleteChannelMessagesStartedEvent>,
    IApply<DeleteParticipantHistoryStartedEvent>,
    IApply<SetChannelDiscussionGroupStartedEvent>,
    IApply<DeleteReplyMessagesStartedEvent>,
    IApply<ForwardMessagesStartedEvent>,
    IApply<PinForwardedChannelMessageStartedEvent>,
    IApply<UnpinAllMessagesStartedEvent>,
    IApply<UpdateMessagePinnedStartedEvent>
{
    public void StartUpdatePinnedMessages(RequestInfo requestInfo, IReadOnlyCollection<SimpleMessageItem> messageItems,
        Peer toPeer, bool pinned, bool pmOneSide)
    {
        Emit(new UpdateMessagePinnedStartedEvent(requestInfo, messageItems, toPeer, pinned, pmOneSide));
    }

    public void StartUnpinAllMessages(RequestInfo requestInfo, IReadOnlyCollection<SimpleMessageItem> messageItems, Peer toPeer)
    {
        Emit(new UnpinAllMessagesStartedEvent(requestInfo, messageItems, toPeer));
    }

    public void StartForwardMessages(RequestInfo requestInfo, bool silent, bool background, bool withMyScore, bool dropAuthor,
        bool dropMediaCaptions, bool noForwards, Peer fromPeer, Peer toPeer,
        List<int> messageIds, List<long> randomIds, int? scheduleDate, Peer? sendAs, bool forwardFromLinkedChannel)
    {
        Emit(new ForwardMessagesStartedEvent(requestInfo, silent, background, withMyScore, dropAuthor, dropMediaCaptions,
            noForwards, fromPeer, toPeer, messageIds, randomIds, scheduleDate, sendAs, forwardFromLinkedChannel));
    }

    public void StartDeleteReplyMessages(RequestInfo requestInfo, long channelId, List<int> messageIds, int newTopMessageId)
    {
        Emit(new DeleteReplyMessagesStartedEvent(requestInfo, channelId, messageIds, newTopMessageId));
    }

    public void StartSetChannelDiscussionGroup(RequestInfo requestInfo, long broadcastChannelId, long? discussionGroupChannelId)
    {
        Emit(new SetChannelDiscussionGroupStartedEvent(requestInfo, broadcastChannelId, discussionGroupChannelId));
    }

    public void StartPinForwardedChannelMessage(RequestInfo requestInfo, long channelId, int messageId)
    {
        Emit(new PinForwardedChannelMessageStartedEvent(requestInfo, channelId, messageId));
    }

    public void StartDeleteMessages(RequestInfo requestInfo, IReadOnlyCollection<MessageItemToBeDeleted> messageItems, bool revoke, bool deleteGroupMessagesForEveryone, int? newTopMessageId, int? newTopMessageIdForOtherParticipant)
    {
        Emit(new DeleteMessagesStartedEvent(requestInfo, messageItems, revoke, deleteGroupMessagesForEveryone, newTopMessageId, newTopMessageIdForOtherParticipant));
    }

    public void StartDeleteHistory(RequestInfo requestInfo, IReadOnlyCollection<MessageItemToBeDeleted> messageItems, bool revoke, bool deleteGroupMessagesForEveryone, bool isDeletePhoneCallHistory)
    {
        Emit(new DeleteHistoryStartedEvent(requestInfo, messageItems, revoke, deleteGroupMessagesForEveryone, isDeletePhoneCallHistory));
    }

    public void StartDeleteChannelMessages(RequestInfo requestInfo,
        long channelId,
        List<int> messageIds,
        int newTopMessageId,
        int? newTopMessageIdForDiscussionGroup,
        long? discussionGroupChannelId,
        IReadOnlyCollection<int>? repliesMessageIds)
    {
        Emit(new DeleteChannelMessagesStartedEvent(requestInfo, channelId, messageIds, newTopMessageId, newTopMessageIdForDiscussionGroup, discussionGroupChannelId, repliesMessageIds));
    }

    public void StartDeleteParticipantHistory(RequestInfo requestInfo, long channelId, List<int> messageIds, int newTopMessageId)
    {
        Emit(new DeleteParticipantHistoryStartedEvent(requestInfo, channelId, messageIds, newTopMessageId));
    }

    public void Apply(DeleteMessagesStartedEvent aggregateEvent)
    {

    }

    public void Apply(DeleteHistoryStartedEvent aggregateEvent)
    {

    }

    public void Apply(DeleteChannelMessagesStartedEvent aggregateEvent)
    {

    }

    public void Apply(DeleteParticipantHistoryStartedEvent aggregateEvent)
    {

    }

    public void Apply(SetChannelDiscussionGroupStartedEvent aggregateEvent)
    {

    }

    public void Apply(DeleteReplyMessagesStartedEvent aggregateEvent)
    {

    }

    public void Apply(ForwardMessagesStartedEvent aggregateEvent)
    {

    }

    public void Apply(PinForwardedChannelMessageStartedEvent aggregateEvent)
    {

    }

    public void Apply(UnpinAllMessagesStartedEvent aggregateEvent)
    {

    }

    public void Apply(UpdateMessagePinnedStartedEvent aggregateEvent)
    {

    }
}