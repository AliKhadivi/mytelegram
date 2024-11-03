﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Adds a user to a chat and sends a service message on it.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_GROUPS_BLOCKED This bot can't be added to groups.
/// 403 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 400 CHAT_ID_INVALID The provided chat id is invalid.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 INPUT_USER_DEACTIVATED The specified user was deleted.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 USERS_TOO_MUCH The maximum number of users has been exceeded (to create a chat, for example).
/// 400 USER_ALREADY_PARTICIPANT The user is already in the group.
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// 400 USER_IS_BLOCKED You were blocked by this user.
/// 403 USER_NOT_MUTUAL_CONTACT The provided user is not a mutual contact.
/// 403 USER_PRIVACY_RESTRICTED The user's privacy settings do not allow you to do this.
/// 400 YOU_BLOCKED_USER You blocked this user.
/// See <a href="https://corefork.telegram.org/method/messages.addChatUser" />
///</summary>
[TlObject(0xcbc6d107)]
public sealed class RequestAddChatUser : IRequest<MyTelegram.Schema.Messages.IInvitedUsers>
{
    public uint ConstructorId => 0xcbc6d107;
    ///<summary>
    /// Chat ID
    ///</summary>
    public long ChatId { get; set; }

    ///<summary>
    /// User ID to be added
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser UserId { get; set; }

    ///<summary>
    /// Number of last messages to be forwarded
    ///</summary>
    public int FwdLimit { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(ChatId);
        writer.Write(UserId);
        writer.Write(FwdLimit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        ChatId = reader.ReadInt64();
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        FwdLimit = reader.ReadInt32();
    }
}
