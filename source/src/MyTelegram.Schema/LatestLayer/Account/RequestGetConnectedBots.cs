﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// See <a href="https://corefork.telegram.org/method/account.getConnectedBots" />
///</summary>
[TlObject(0x4ea4c80f)]
public sealed class RequestGetConnectedBots : IRequest<MyTelegram.Schema.Account.IConnectedBots>
{
    public uint ConstructorId => 0x4ea4c80f;

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);

    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {

    }
}