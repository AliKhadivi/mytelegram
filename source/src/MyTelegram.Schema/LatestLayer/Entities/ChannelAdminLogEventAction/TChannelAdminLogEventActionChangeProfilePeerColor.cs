﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// The <a href="https://corefork.telegram.org/api/colors">profile accent color</a> was changed
/// See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeProfilePeerColor" />
///</summary>
[TlObject(0x5e477b25)]
public sealed class TChannelAdminLogEventActionChangeProfilePeerColor : IChannelAdminLogEventAction
{
    public uint ConstructorId => 0x5e477b25;
    ///<summary>
    /// Previous accent palette
    /// See <a href="https://corefork.telegram.org/type/PeerColor" />
    ///</summary>
    public MyTelegram.Schema.IPeerColor PrevValue { get; set; }

    ///<summary>
    /// New accent palette
    /// See <a href="https://corefork.telegram.org/type/PeerColor" />
    ///</summary>
    public MyTelegram.Schema.IPeerColor NewValue { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PrevValue);
        writer.Write(NewValue);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PrevValue = reader.Read<MyTelegram.Schema.IPeerColor>();
        NewValue = reader.Read<MyTelegram.Schema.IPeerColor>();
    }
}