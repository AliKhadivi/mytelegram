﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Enable or disable the <a href="https://corefork.telegram.org/api/antispam">native antispam system</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHAT_NOT_MODIFIED No changes were made to chat information because the new information you passed is identical to the current information.
/// See <a href="https://corefork.telegram.org/method/channels.toggleAntiSpam" />
///</summary>
[TlObject(0x68f3e4eb)]
public sealed class RequestToggleAntiSpam : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x68f3e4eb;
    ///<summary>
    /// Supergroup ID. The specified supergroup must have at least <code>telegram_antispam_group_size_min</code> members to enable antispam functionality, as specified by the <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration parameters</a>.
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// Enable or disable the native antispam system.
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool Enabled { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
        writer.Write(Enabled);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        Enabled = reader.Read();
    }
}
