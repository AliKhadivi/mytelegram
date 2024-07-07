﻿namespace MyTelegram.Domain.Events.User;

public class UserProfilePhotoChangedEvent(
    RequestInfo requestInfo,
    long userId,
    long photoId,
    bool fallback)
    : RequestAggregateEvent2<UserAggregate, UserId>(requestInfo)
{
    public long UserId { get; } = userId;
    public long PhotoId { get; } = photoId;

    public bool Fallback { get; } = fallback;
}
