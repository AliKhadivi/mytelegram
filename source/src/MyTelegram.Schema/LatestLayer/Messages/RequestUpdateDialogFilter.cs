﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Update <a href="https://corefork.telegram.org/api/folders">folder</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHATLIST_EXCLUDE_INVALID The specified <code>exclude_peers</code> are invalid.
/// 400 CHAT_ID_INVALID The provided chat id is invalid.
/// 400 FILTER_ID_INVALID The specified filter ID is invalid.
/// 400 FILTER_INCLUDE_EMPTY The include_peers vector of the filter is empty.
/// 400 FILTER_TITLE_EMPTY The title field of the filter is empty.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.updateDialogFilter" />
///</summary>
[TlObject(0x1ad4a04a)]
public sealed class RequestUpdateDialogFilter : IRequest<IBool>
{
    public uint ConstructorId => 0x1ad4a04a;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/folders">Folder</a> ID
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/folders">Folder</a> info
    /// See <a href="https://corefork.telegram.org/type/DialogFilter" />
    ///</summary>
    public MyTelegram.Schema.IDialogFilter? Filter { get; set; }

    public void ComputeFlag()
    {
        if (Filter != null) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Id);
        if (Flags[0]) { writer.Write(Filter); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Id = reader.ReadInt32();
        if (Flags[0]) { Filter = reader.Read<MyTelegram.Schema.IDialogFilter>(); }
    }
}
