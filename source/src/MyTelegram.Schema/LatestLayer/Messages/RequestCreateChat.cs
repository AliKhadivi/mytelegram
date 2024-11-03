﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Creates a new chat.
/// <para>Possible errors</para>
/// Code Type Description
/// 500 CHAT_ID_GENERATE_FAILED Failure while generating the chat ID.
/// 400 CHAT_INVALID Invalid chat.
/// 400 CHAT_TITLE_EMPTY No chat title provided.
/// 400 INPUT_USER_DEACTIVATED The specified user was deleted.
/// 400 TTL_PERIOD_INVALID The specified TTL period is invalid.
/// 400 USERS_TOO_FEW Not enough users (to create a chat, for example).
/// 406 USER_RESTRICTED You're spamreported, you can't create channels or chats.
/// See <a href="https://corefork.telegram.org/method/messages.createChat" />
///</summary>
[TlObject(0x92ceddd4)]
public sealed class RequestCreateChat : IRequest<MyTelegram.Schema.Messages.IInvitedUsers>
{
    public uint ConstructorId => 0x92ceddd4;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// List of user IDs to be invited
    ///</summary>
    public TVector<MyTelegram.Schema.IInputUser> Users { get; set; }

    ///<summary>
    /// Chat name
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// Time-to-live of all messages that will be sent in the chat: once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well. You can use <a href="https://corefork.telegram.org/method/messages.setDefaultHistoryTTL">messages.setDefaultHistoryTTL</a> to edit this value later.
    ///</summary>
    public int? TtlPeriod { get; set; }

    public void ComputeFlag()
    {
        if (/*TtlPeriod != 0 && */TtlPeriod.HasValue) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Users);
        writer.Write(Title);
        if (Flags[0]) { writer.Write(TtlPeriod.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Users = reader.Read<TVector<MyTelegram.Schema.IInputUser>>();
        Title = reader.ReadString();
        if (Flags[0]) { TtlPeriod = reader.ReadInt32(); }
    }
}
