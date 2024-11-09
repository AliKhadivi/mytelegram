﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// See <a href="https://corefork.telegram.org/method/messages.getSponsoredMessages" />
///</summary>
[TlObject(0x9bd2f439)]
public sealed class RequestGetSponsoredMessages : IRequest<MyTelegram.Schema.Messages.ISponsoredMessages>
{
    public uint ConstructorId => 0x9bd2f439;
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
    }
}
