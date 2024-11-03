﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Premium;

///<summary>
/// Gets the current <a href="https://corefork.telegram.org/api/boost">number of boosts</a> of a channel/supergroup.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/premium.getBoostsStatus" />
///</summary>
[TlObject(0x42f1f61)]
public sealed class RequestGetBoostsStatus : IRequest<MyTelegram.Schema.Premium.IBoostsStatus>
{
    public uint ConstructorId => 0x42f1f61;
    ///<summary>
    /// The peer.
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
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
