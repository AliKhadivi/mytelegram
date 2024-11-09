﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Transfer channel ownership
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNELS_ADMIN_PUBLIC_TOO_MUCH You're admin of too many public channels, make some channels private to change the username of this channel.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 400 CHAT_NOT_MODIFIED No changes were made to chat information because the new information you passed is identical to the current information.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 PASSWORD_HASH_INVALID The provided password hash is invalid.
/// 400 PASSWORD_MISSING You must <a href="https://corefork.telegram.org/api/srp">enable 2FA</a> before executing this operation.
/// 400 PASSWORD_TOO_FRESH_%d The password was modified less than 24 hours ago, try again in %d seconds.
/// 400 SESSION_TOO_FRESH_%d This session was created less than 24 hours ago, try again in %d seconds.
/// 400 SRP_ID_INVALID Invalid SRP ID provided.
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// See <a href="https://corefork.telegram.org/method/channels.editCreator" />
///</summary>
[TlObject(0x8f38cd1f)]
public sealed class RequestEditCreator : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x8f38cd1f;
    ///<summary>
    /// Channel
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// New channel owner
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser UserId { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/srp">2FA password</a> of account
    /// See <a href="https://corefork.telegram.org/type/InputCheckPasswordSRP" />
    ///</summary>
    public MyTelegram.Schema.IInputCheckPasswordSRP Password { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
        writer.Write(UserId);
        writer.Write(Password);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        Password = reader.Read<MyTelegram.Schema.IInputCheckPasswordSRP>();
    }
}
