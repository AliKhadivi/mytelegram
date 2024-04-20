﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// How a certain peer reacted to a story
/// See <a href="https://corefork.telegram.org/constructor/storyReaction" />
///</summary>
[TlObject(0x6090d6d5)]
public sealed class TStoryReaction : IStoryReaction
{
    public uint ConstructorId => 0x6090d6d5;
    ///<summary>
    /// The peer
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer PeerId { get; set; }

    ///<summary>
    /// Reaction date
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// The reaction
    /// See <a href="https://corefork.telegram.org/type/Reaction" />
    ///</summary>
    public MyTelegram.Schema.IReaction Reaction { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PeerId);
        writer.Write(Date);
        writer.Write(Reaction);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PeerId = reader.Read<MyTelegram.Schema.IPeer>();
        Date = reader.ReadInt32();
        Reaction = reader.Read<MyTelegram.Schema.IReaction>();
    }
}