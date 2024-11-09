﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/messageReactor" />
///</summary>
[TlObject(0x4ba3a95a)]
public sealed class TMessageReactor : IMessageReactor
{
    public uint ConstructorId => 0x4ba3a95a;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Top { get; set; }
    public bool My { get; set; }
    public bool Anonymous { get; set; }
    public MyTelegram.Schema.IPeer? PeerId { get; set; }
    public int Count { get; set; }

    public void ComputeFlag()
    {
        if (Top) { Flags[0] = true; }
        if (My) { Flags[1] = true; }
        if (Anonymous) { Flags[2] = true; }
        if (PeerId != null) { Flags[3] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[3]) { writer.Write(PeerId); }
        writer.Write(Count);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Top = true; }
        if (Flags[1]) { My = true; }
        if (Flags[2]) { Anonymous = true; }
        if (Flags[3]) { PeerId = reader.Read<MyTelegram.Schema.IPeer>(); }
        Count = reader.ReadInt32();
    }
}