﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// See <a href="https://corefork.telegram.org/method/payments.fulfillStarsSubscription" />
///</summary>
[TlObject(0xcc5bebb3)]
public sealed class RequestFulfillStarsSubscription : IRequest<IBool>
{
    public uint ConstructorId => 0xcc5bebb3;
    public MyTelegram.Schema.IInputPeer Peer { get; set; }
    public string SubscriptionId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(SubscriptionId);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        SubscriptionId = reader.ReadString();
    }
}
