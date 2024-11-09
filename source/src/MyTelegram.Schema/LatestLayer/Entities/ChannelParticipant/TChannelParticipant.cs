﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Channel/supergroup participant
/// See <a href="https://corefork.telegram.org/constructor/channelParticipant" />
///</summary>
[TlObject(0xcb397619)]
public sealed class TChannelParticipant : IChannelParticipant
{
    public uint ConstructorId => 0xcb397619;
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Participant user ID
    ///</summary>
    public long UserId { get; set; }

    ///<summary>
    /// Date joined
    ///</summary>
    public int Date { get; set; }
    public int? SubscriptionUntilDate { get; set; }

    public void ComputeFlag()
    {
        if (/*SubscriptionUntilDate != 0 && */SubscriptionUntilDate.HasValue) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(UserId);
        writer.Write(Date);
        if (Flags[0]) { writer.Write(SubscriptionUntilDate.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        UserId = reader.ReadInt64();
        Date = reader.ReadInt32();
        if (Flags[0]) { SubscriptionUntilDate = reader.ReadInt32(); }
    }
}