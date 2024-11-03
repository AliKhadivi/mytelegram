﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Get <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a> we're admin in. Usually called when the user exceeds the <a href="https://corefork.telegram.org/constructor/config">limit</a> for owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, and the user is given the choice to remove one of his channels/supergroups/geogroups.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNELS_ADMIN_LOCATED_TOO_MUCH The user has reached the limit of public geogroups.
/// 400 CHANNELS_ADMIN_PUBLIC_TOO_MUCH You're admin of too many public channels, make some channels private to change the username of this channel.
/// See <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels" />
///</summary>
[TlObject(0xf8b036af)]
public sealed class RequestGetAdminedPublicChannels : IRequest<MyTelegram.Schema.Messages.IChats>
{
    public uint ConstructorId => 0xf8b036af;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Get geogroups
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ByLocation { get; set; }

    ///<summary>
    /// If set and the user has reached the limit of owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, instead of returning the channel list one of the specified <a href="https://corefork.telegram.org/htmls/method/channels.getAdminedPublicChannels.html#possible-errors">errors</a> will be returned.<br>Useful to check if a new public channel can indeed be created, even before asking the user to enter a channel username to use in <a href="https://corefork.telegram.org/method/channels.checkUsername">channels.checkUsername</a>/<a href="https://corefork.telegram.org/method/channels.updateUsername">channels.updateUsername</a>.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CheckLimit { get; set; }

    ///<summary>
    /// Set this flag to only fetch the full list of channels that may be passed to <a href="https://corefork.telegram.org/method/account.updatePersonalChannel">account.updatePersonalChannel</a> to <a href="https://corefork.telegram.org/api/profile#personal-channel">display them on our profile page</a>.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ForPersonal { get; set; }

    public void ComputeFlag()
    {
        if (ByLocation) { Flags[0] = true; }
        if (CheckLimit) { Flags[1] = true; }
        if (ForPersonal) { Flags[2] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);

    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { ByLocation = true; }
        if (Flags[1]) { CheckLimit = true; }
        if (Flags[2]) { ForPersonal = true; }
    }
}
