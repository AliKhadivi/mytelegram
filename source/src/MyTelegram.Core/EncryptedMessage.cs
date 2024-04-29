﻿//namespace MyTelegram.Core;

////[MemoryPackable]

namespace MyTelegram.Core;

public record EncryptedMessage(
    long AuthKeyId,
    byte[] MsgKey,
    byte[] EncryptedData,
    //ReadOnlyMemory<byte> MsgKey,
    //ReadOnlyMemory<byte> EncryptedData,
    string ConnectionId,
    ConnectionType? ConnectionType,
    string? ClientIp,
    Guid RequestId,
    long Date
)
{
    public string? ClientIp { get; set; } = ClientIp;
}