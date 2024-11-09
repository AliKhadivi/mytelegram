﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// List of <a href="https://corefork.telegram.org/api/reactions">message reactions</a>
/// See <a href="https://corefork.telegram.org/constructor/messages.reactions" />
///</summary>
[TlObject(0xeafdf716)]
public sealed class TReactions : IReactions
{
    public uint ConstructorId => 0xeafdf716;
    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    public long Hash { get; set; }

    ///<summary>
    /// Reactions
    ///</summary>
    public TVector<MyTelegram.Schema.IReaction> Reactions { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Hash);
        writer.Write(Reactions);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Hash = reader.ReadInt64();
        Reactions = reader.Read<TVector<MyTelegram.Schema.IReaction>>();
    }
}