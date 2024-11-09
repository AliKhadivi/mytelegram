﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about a <a href="https://corefork.telegram.org/api/channel">chat</a>, shared by a user with the currently logged in bot using <a href="https://corefork.telegram.org/method/messages.sendBotRequestedPeer">messages.sendBotRequestedPeer</a>.All fields except the ID are optional, and will be populated if present on the chosen chat, according to the parameters of the requesting <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonRequestPeer">inputKeyboardButtonRequestPeer</a>.
/// See <a href="https://corefork.telegram.org/constructor/requestedPeerChat" />
///</summary>
[TlObject(0x7307544f)]
public sealed class TRequestedPeerChat : IRequestedPeer
{
    public uint ConstructorId => 0x7307544f;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Chat ID.
    ///</summary>
    public long ChatId { get; set; }

    ///<summary>
    /// Chat title.
    ///</summary>
    public string? Title { get; set; }

    ///<summary>
    /// Chat photo.
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    public MyTelegram.Schema.IPhoto? Photo { get; set; }

    public void ComputeFlag()
    {
        if (Title != null) { Flags[0] = true; }
        if (Photo != null) { Flags[2] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(ChatId);
        if (Flags[0]) { writer.Write(Title); }
        if (Flags[2]) { writer.Write(Photo); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        ChatId = reader.ReadInt64();
        if (Flags[0]) { Title = reader.ReadString(); }
        if (Flags[2]) { Photo = reader.Read<MyTelegram.Schema.IPhoto>(); }
    }
}