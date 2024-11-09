﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Get preview of webpage
/// <para>Possible errors</para>
/// Code Type Description
/// 400 ENTITY_BOUNDS_INVALID A specified <a href="https://corefork.telegram.org/api/entities#entity-length">entity offset or length</a> is invalid, see <a href="https://corefork.telegram.org/api/entities#entity-length">here&nbsp;»</a> for info on how to properly compute the entity offset/length.
/// 400 MESSAGE_EMPTY The provided message is empty.
/// See <a href="https://corefork.telegram.org/method/messages.getWebPagePreview" />
///</summary>
[TlObject(0x8b68b0cc)]
public sealed class RequestGetWebPagePreview : IRequest<MyTelegram.Schema.IMessageMedia>
{
    public uint ConstructorId => 0x8b68b0cc;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Message from which to extract the preview
    ///</summary>
    public string Message { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a>
    ///</summary>
    public TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }

    public void ComputeFlag()
    {
        if (Entities?.Count > 0) { Flags[3] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Message);
        if (Flags[3]) { writer.Write(Entities); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Message = reader.ReadString();
        if (Flags[3]) { Entities = reader.Read<TVector<MyTelegram.Schema.IMessageEntity>>(); }
    }
}
