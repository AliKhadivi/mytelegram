﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// See <a href="https://corefork.telegram.org/method/payments.saveStarGift" />
///</summary>
[TlObject(0x87acf08e)]
public sealed class RequestSaveStarGift : IRequest<IBool>
{
    public uint ConstructorId => 0x87acf08e;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Unsave { get; set; }
    public MyTelegram.Schema.IInputUser UserId { get; set; }
    public int MsgId { get; set; }

    public void ComputeFlag()
    {
        if (Unsave) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(UserId);
        writer.Write(MsgId);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Unsave = true; }
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        MsgId = reader.ReadInt32();
    }
}
