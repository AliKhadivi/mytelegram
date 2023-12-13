﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Get <a href="https://corefork.telegram.org/api/forum">topics of a forum</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_FORUM_MISSING This supergroup is not a forum.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// See <a href="https://corefork.telegram.org/method/channels.getForumTopics" />
///</summary>
[TlObject(0xde560d1)]
public sealed class RequestGetForumTopics : IRequest<MyTelegram.Schema.Messages.IForumTopics>
{
    public uint ConstructorId => 0xde560d1;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Supergroup
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// Search query
    ///</summary>
    public string? Q { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>
    ///</summary>
    public int OffsetDate { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>
    ///</summary>
    public int OffsetId { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>
    ///</summary>
    public int OffsetTopic { get; set; }

    ///<summary>
    /// Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {
        if (Q != null) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Channel);
        if (Flags[0]) { writer.Write(Q); }
        writer.Write(OffsetDate);
        writer.Write(OffsetId);
        writer.Write(OffsetTopic);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        if (Flags[0]) { Q = reader.ReadString(); }
        OffsetDate = reader.ReadInt32();
        OffsetId = reader.ReadInt32();
        OffsetTopic = reader.ReadInt32();
        Limit = reader.ReadInt32();
    }
}