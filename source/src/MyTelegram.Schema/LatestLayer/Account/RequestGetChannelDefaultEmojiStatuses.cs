﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Get a list of default suggested <a href="https://corefork.telegram.org/api/emoji-status">channel emoji statuses</a>.
/// See <a href="https://corefork.telegram.org/method/account.getChannelDefaultEmojiStatuses" />
///</summary>
[TlObject(0x7727a7d5)]
public sealed class RequestGetChannelDefaultEmojiStatuses : IRequest<MyTelegram.Schema.Account.IEmojiStatuses>
{
    public uint ConstructorId => 0x7727a7d5;
    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a>
    ///</summary>
    public long Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Hash = reader.ReadInt64();
    }
}
