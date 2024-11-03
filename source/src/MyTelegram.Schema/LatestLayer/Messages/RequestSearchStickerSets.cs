﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Search for stickersets
/// See <a href="https://corefork.telegram.org/method/messages.searchStickerSets" />
///</summary>
[TlObject(0x35705b8a)]
public sealed class RequestSearchStickerSets : IRequest<MyTelegram.Schema.Messages.IFoundStickerSets>
{
    public uint ConstructorId => 0x35705b8a;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Exclude featured stickersets from results
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ExcludeFeatured { get; set; }

    ///<summary>
    /// Query string
    ///</summary>
    public string Q { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.
    ///</summary>
    public long Hash { get; set; }

    public void ComputeFlag()
    {
        if (ExcludeFeatured) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Q);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { ExcludeFeatured = true; }
        Q = reader.ReadString();
        Hash = reader.ReadInt64();
    }
}
