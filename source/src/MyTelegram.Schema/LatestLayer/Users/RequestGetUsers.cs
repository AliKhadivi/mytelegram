﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Users;

///<summary>
/// Returns basic user info according to their identifiers.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 FROM_MESSAGE_BOT_DISABLED Bots can't use fromMessage min constructors.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 USER_BANNED_IN_CHANNEL You're banned from sending messages in supergroups/channels.
/// See <a href="https://corefork.telegram.org/method/users.getUsers" />
///</summary>
[TlObject(0xd91a548)]
public sealed class RequestGetUsers : IRequest<TVector<MyTelegram.Schema.IUser>>
{
    public uint ConstructorId => 0xd91a548;
    ///<summary>
    /// List of user identifiers
    ///</summary>
    public TVector<MyTelegram.Schema.IInputUser> Id { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Id);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Id = reader.Read<TVector<MyTelegram.Schema.IInputUser>>();
    }
}
