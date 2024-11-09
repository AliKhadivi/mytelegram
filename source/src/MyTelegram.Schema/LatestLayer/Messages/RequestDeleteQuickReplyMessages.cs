﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Delete one or more messages from a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>. This will also emit an <a href="https://corefork.telegram.org/constructor/updateDeleteQuickReplyMessages">updateDeleteQuickReplyMessages</a> update.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 SHORTCUT_INVALID The specified shortcut is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.deleteQuickReplyMessages" />
///</summary>
[TlObject(0xe105e910)]
public sealed class RequestDeleteQuickReplyMessages : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xe105e910;
    ///<summary>
    /// <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">Shortcut ID</a>.
    ///</summary>
    public int ShortcutId { get; set; }

    ///<summary>
    /// IDs of shortcut messages to delete.
    ///</summary>
    public TVector<int> Id { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(ShortcutId);
        writer.Write(Id);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        ShortcutId = reader.ReadInt32();
        Id = reader.Read<TVector<int>>();
    }
}
