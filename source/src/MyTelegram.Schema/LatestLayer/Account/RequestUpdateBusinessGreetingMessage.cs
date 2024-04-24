﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// See <a href="https://corefork.telegram.org/method/account.updateBusinessGreetingMessage" />
///</summary>
[TlObject(0x66cdafc4)]
public sealed class RequestUpdateBusinessGreetingMessage : IRequest<IBool>
{
    public uint ConstructorId => 0x66cdafc4;
    public BitArray Flags { get; set; } = new BitArray(32);
    public MyTelegram.Schema.IInputBusinessGreetingMessage? Message { get; set; }

    public void ComputeFlag()
    {
        if (Message != null) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[0]) { writer.Write(Message); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Message = reader.Read<MyTelegram.Schema.IInputBusinessGreetingMessage>(); }
    }
}