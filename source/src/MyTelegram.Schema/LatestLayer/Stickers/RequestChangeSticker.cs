﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stickers;

///<summary>
/// Update the keywords, emojis or <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask coordinates</a> of a sticker.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKER_INVALID The provided sticker is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.changeSticker" />
///</summary>
[TlObject(0xf5537ebc)]
public sealed class RequestChangeSticker : IRequest<MyTelegram.Schema.Messages.IStickerSet>
{
    public uint ConstructorId => 0xf5537ebc;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// The sticker
    /// See <a href="https://corefork.telegram.org/type/InputDocument" />
    ///</summary>
    public MyTelegram.Schema.IInputDocument Sticker { get; set; }

    ///<summary>
    /// If set, updates the emoji list associated to the sticker
    ///</summary>
    public string? Emoji { get; set; }

    ///<summary>
    /// If set, updates the <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask coordinates</a>
    /// See <a href="https://corefork.telegram.org/type/MaskCoords" />
    ///</summary>
    public MyTelegram.Schema.IMaskCoords? MaskCoords { get; set; }

    ///<summary>
    /// If set, updates the sticker keywords (separated by commas). Can't be provided for mask stickers.
    ///</summary>
    public string? Keywords { get; set; }

    public void ComputeFlag()
    {
        if (Emoji != null) { Flags[0] = true; }
        if (MaskCoords != null) { Flags[1] = true; }
        if (Keywords != null) { Flags[2] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Sticker);
        if (Flags[0]) { writer.Write(Emoji); }
        if (Flags[1]) { writer.Write(MaskCoords); }
        if (Flags[2]) { writer.Write(Keywords); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Sticker = reader.Read<MyTelegram.Schema.IInputDocument>();
        if (Flags[0]) { Emoji = reader.ReadString(); }
        if (Flags[1]) { MaskCoords = reader.Read<MyTelegram.Schema.IMaskCoords>(); }
        if (Flags[2]) { Keywords = reader.ReadString(); }
    }
}
