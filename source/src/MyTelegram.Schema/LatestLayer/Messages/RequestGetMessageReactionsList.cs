﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Get <a href="https://corefork.telegram.org/api/reactions">message reaction</a> list, along with the sender of each reaction.
/// <para>Possible errors</para>
/// Code Type Description
/// 403 BROADCAST_FORBIDDEN Channel poll voters and reactions cannot be fetched to prevent deanonymization.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// See <a href="https://corefork.telegram.org/method/messages.getMessageReactionsList" />
///</summary>
[TlObject(0x461b3f48)]
public sealed class RequestGetMessageReactionsList : IRequest<MyTelegram.Schema.Messages.IMessageReactionsList>
{
    public uint ConstructorId => 0x461b3f48;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Peer
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// Message ID
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// Get only reactions of this type
    /// See <a href="https://corefork.telegram.org/type/Reaction" />
    ///</summary>
    public MyTelegram.Schema.IReaction? Reaction { get; set; }

    ///<summary>
    /// Offset for pagination (taken from the <code>next_offset</code> field of the returned <a href="https://corefork.telegram.org/type/messages.MessageReactionsList">messages.MessageReactionsList</a>); empty in the first request.
    ///</summary>
    public string? Offset { get; set; }

    ///<summary>
    /// Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {
        if (Reaction != null) { Flags[0] = true; }
        if (Offset != null) { Flags[1] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(Id);
        if (Flags[0]) { writer.Write(Reaction); }
        if (Flags[1]) { writer.Write(Offset); }
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Id = reader.ReadInt32();
        if (Flags[0]) { Reaction = reader.Read<MyTelegram.Schema.IReaction>(); }
        if (Flags[1]) { Offset = reader.ReadString(); }
        Limit = reader.ReadInt32();
    }
}
