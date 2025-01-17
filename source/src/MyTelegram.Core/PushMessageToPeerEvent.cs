﻿namespace MyTelegram.Core;

public record PushMessageToPeerEvent(
    int PeerType,
    long PeerId,
    byte[] Data,
    long ExcludeAuthKeyId,
    long ExcludeUid,
    long OnlySendToThisAuthKeyId,
    int Pts,
    long GlobalSeqNo) : ISessionMessage;