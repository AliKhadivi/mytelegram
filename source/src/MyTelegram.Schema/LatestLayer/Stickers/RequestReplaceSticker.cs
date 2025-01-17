﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stickers;

///<summary>
/// Replace a sticker in a <a href="https://corefork.telegram.org/api/stickers">stickerset »</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKER_INVALID The provided sticker is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.replaceSticker" />
///</summary>
[TlObject(0x4696459a)]
public sealed class RequestReplaceSticker : IRequest<MyTelegram.Schema.Messages.IStickerSet>
{
    public uint ConstructorId => 0x4696459a;
    ///<summary>
    /// Old sticker document.
    /// See <a href="https://corefork.telegram.org/type/InputDocument" />
    ///</summary>
    public MyTelegram.Schema.IInputDocument Sticker { get; set; }

    ///<summary>
    /// New sticker.
    /// See <a href="https://corefork.telegram.org/type/InputStickerSetItem" />
    ///</summary>
    public MyTelegram.Schema.IInputStickerSetItem NewSticker { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Sticker);
        writer.Write(NewSticker);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Sticker = reader.Read<MyTelegram.Schema.IInputDocument>();
        NewSticker = reader.Read<MyTelegram.Schema.IInputStickerSetItem>();
    }
}
