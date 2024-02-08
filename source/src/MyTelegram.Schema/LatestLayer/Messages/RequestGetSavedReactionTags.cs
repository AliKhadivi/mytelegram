﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// See <a href="https://corefork.telegram.org/method/messages.getSavedReactionTags" />
///</summary>
[TlObject(0x3637e05b)]
public sealed class RequestGetSavedReactionTags : IRequest<MyTelegram.Schema.Messages.ISavedReactionTags>
{
    public uint ConstructorId => 0x3637e05b;
    public BitArray Flags { get; set; } = new BitArray(32);
    public MyTelegram.Schema.IInputPeer? Peer { get; set; }
    public long Hash { get; set; }

    public void ComputeFlag()
    {
        if (Peer != null) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[0]) { writer.Write(Peer); }
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Peer = reader.Read<MyTelegram.Schema.IInputPeer>(); }
        Hash = reader.ReadInt64();
    }
}
