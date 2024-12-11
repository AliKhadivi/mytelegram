﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


[TlObject(0x3c6a84d4)]
public sealed class TPQInnerDataTemp : IPQInnerData
{
    public uint ConstructorId => 0x3c6a84d4;
    public byte[] Pq { get; set; }
    public byte[] P { get; set; }
    public byte[] Q { get; set; }
    public byte[] Nonce { get; set; }
    public byte[] ServerNonce { get; set; }
    public byte[] NewNonce { get; set; }
    public int ExpiresIn { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Pq);
        writer.Write(P);
        writer.Write(Q);
        writer.WriteRawBytes(Nonce);
        writer.WriteRawBytes(ServerNonce);
        writer.WriteRawBytes(NewNonce);
        writer.Write(ExpiresIn);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Pq = reader.ReadBytes();
        P = reader.ReadBytes();
        Q = reader.ReadBytes();
        Nonce = reader.ReadInt128();
        ServerNonce = reader.ReadInt128();
        NewNonce = reader.ReadInt256();
        ExpiresIn = reader.ReadInt32();
    }
}