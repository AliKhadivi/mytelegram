﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Method for fetching previously featured stickers
/// See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers" />
///</summary>
[TlObject(0x7ed094a1)]
public sealed class RequestGetOldFeaturedStickers : IRequest<MyTelegram.Schema.Messages.IFeaturedStickers>
{
    public uint ConstructorId => 0x7ed094a1;
    ///<summary>
    /// Offset
    ///</summary>
    public int Offset { get; set; }

    ///<summary>
    /// Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>
    ///</summary>
    public int Limit { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.
    ///</summary>
    public long Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Offset);
        writer.Write(Limit);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Offset = reader.ReadInt32();
        Limit = reader.ReadInt32();
        Hash = reader.ReadInt64();
    }
}
