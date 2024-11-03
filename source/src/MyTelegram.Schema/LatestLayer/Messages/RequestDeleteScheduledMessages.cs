﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Delete scheduled messages
/// <para>Possible errors</para>
/// Code Type Description
/// 403 MESSAGE_DELETE_FORBIDDEN You can't delete one of the messages you tried to delete, most likely because it is a service message.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages" />
///</summary>
[TlObject(0x59ae2b16)]
public sealed class RequestDeleteScheduledMessages : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x59ae2b16;
    ///<summary>
    /// Peer
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// Scheduled message IDs
    ///</summary>
    public TVector<int> Id { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(Id);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Id = reader.Read<TVector<int>>();
    }
}
