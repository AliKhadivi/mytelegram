﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// See <a href="https://corefork.telegram.org/method/payments.getUserStarGifts" />
///</summary>
[TlObject(0x5e72c7e1)]
public sealed class RequestGetUserStarGifts : IRequest<MyTelegram.Schema.Payments.IUserStarGifts>
{
    public uint ConstructorId => 0x5e72c7e1;
    public MyTelegram.Schema.IInputUser UserId { get; set; }
    public string Offset { get; set; }
    public int Limit { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(UserId);
        writer.Write(Offset);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        Offset = reader.ReadString();
        Limit = reader.ReadInt32();
    }
}
