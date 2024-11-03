﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Fetch (a subset or all) messages in a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 SHORTCUT_INVALID The specified shortcut is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getQuickReplyMessages" />
///</summary>
[TlObject(0x94a495c3)]
public sealed class RequestGetQuickReplyMessages : IRequest<MyTelegram.Schema.Messages.IMessages>
{
    public uint ConstructorId => 0x94a495c3;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Quick reply shortcut ID.
    ///</summary>
    public int ShortcutId { get; set; }

    ///<summary>
    /// IDs of the messages to fetch, if empty fetches all of them.
    ///</summary>
    public TVector<int>? Id { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    public long Hash { get; set; }

    public void ComputeFlag()
    {
        if (Id?.Count > 0) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(ShortcutId);
        if (Flags[0]) { writer.Write(Id); }
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        ShortcutId = reader.ReadInt32();
        if (Flags[0]) { Id = reader.Read<TVector<int>>(); }
        Hash = reader.ReadInt64();
    }
}
