﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Disable ads on the specified channel, for all users.Available only after reaching at least the <a href="https://corefork.telegram.org/api/boost">boost level »</a> specified in the <a href="https://corefork.telegram.org/api/config#channel-restrict-sponsored-level-min"><code>channel_restrict_sponsored_level_min</code> »</a> config parameter.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// See <a href="https://corefork.telegram.org/method/channels.restrictSponsoredMessages" />
///</summary>
[TlObject(0x9ae91519)]
public sealed class RequestRestrictSponsoredMessages : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x9ae91519;
    ///<summary>
    /// The channel.
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// Whether to disable or re-enable ads.
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool Restricted { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
        writer.Write(Restricted);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        Restricted = reader.Read();
    }
}
