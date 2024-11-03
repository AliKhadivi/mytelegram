﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Featured stickersets
/// See <a href="https://corefork.telegram.org/constructor/messages.featuredStickers" />
///</summary>
[TlObject(0xbe382906)]
public sealed class TFeaturedStickers : IFeaturedStickers
{
    public uint ConstructorId => 0xbe382906;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether this is a premium stickerset
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Premium { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    public long Hash { get; set; }

    ///<summary>
    /// Total number of featured stickers
    ///</summary>
    public int Count { get; set; }

    ///<summary>
    /// Featured stickersets
    ///</summary>
    public TVector<MyTelegram.Schema.IStickerSetCovered> Sets { get; set; }

    ///<summary>
    /// IDs of new featured stickersets
    ///</summary>
    public TVector<long> Unread { get; set; }

    public void ComputeFlag()
    {
        if (Premium) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Hash);
        writer.Write(Count);
        writer.Write(Sets);
        writer.Write(Unread);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Premium = true; }
        Hash = reader.ReadInt64();
        Count = reader.ReadInt32();
        Sets = reader.Read<TVector<MyTelegram.Schema.IStickerSetCovered>>();
        Unread = reader.Read<TVector<long>>();
    }
}