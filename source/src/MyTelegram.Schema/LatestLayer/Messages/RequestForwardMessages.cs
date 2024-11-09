﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Forwards messages by their IDs.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BROADCAST_PUBLIC_VOTERS_FORBIDDEN You can't forward polls with public voters.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 406 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 403 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 406 CHAT_FORWARDS_RESTRICTED You can't forward messages from a protected chat.
/// 403 CHAT_GUEST_SEND_FORBIDDEN You join the discussion group before commenting, see <a href="https://corefork.telegram.org/api/discussion#requiring-users-to-join-the-group">here&nbsp;»</a> for more info.
/// 400 CHAT_ID_INVALID The provided chat id is invalid.
/// 400 CHAT_RESTRICTED You can't send messages in this chat, you were restricted.
/// 403 CHAT_SEND_AUDIOS_FORBIDDEN You can't send audio messages in this chat.
/// 403 CHAT_SEND_DOCS_FORBIDDEN You can't send documents in this chat.
/// 403 CHAT_SEND_GAME_FORBIDDEN You can't send a game to this chat.
/// 403 CHAT_SEND_GIFS_FORBIDDEN You can't send gifs in this chat.
/// 403 CHAT_SEND_MEDIA_FORBIDDEN You can't send media in this chat.
/// 403 CHAT_SEND_PHOTOS_FORBIDDEN You can't send photos in this chat.
/// 403 CHAT_SEND_PLAIN_FORBIDDEN You can't send non-media (text) messages in this chat.
/// 403 CHAT_SEND_POLL_FORBIDDEN You can't send polls in this chat.
/// 403 CHAT_SEND_STICKERS_FORBIDDEN You can't send stickers in this chat.
/// 403 CHAT_SEND_VIDEOS_FORBIDDEN You can't send videos in this chat.
/// 403 CHAT_SEND_VOICES_FORBIDDEN You can't send voice recordings in this chat.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 GROUPED_MEDIA_INVALID Invalid grouped media.
/// 400 INPUT_USER_DEACTIVATED The specified user was deleted.
/// 400 MEDIA_EMPTY The provided media object is invalid.
/// 400 MESSAGE_IDS_EMPTY No message ids were provided.
/// 400 MESSAGE_ID_INVALID The provided message id is invalid.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 406 PAYMENT_UNSUPPORTED A detailed description of the error will be received separately as described <a href="https://corefork.telegram.org/api/errors#406-not-acceptable">here&nbsp;»</a>.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 403 PREMIUM_ACCOUNT_REQUIRED A premium account is required to execute this action.
/// 406 PRIVACY_PREMIUM_REQUIRED You need a <a href="https://corefork.telegram.org/api/premium">Telegram Premium subscription</a> to send a message to this user.
/// 400 QUICK_REPLIES_TOO_MUCH A maximum of <a href="https://corefork.telegram.org/api/config#quick-replies-limit">appConfig.<code>quick_replies_limit</code></a> shortcuts may be created, the limit was reached.
/// 400 QUIZ_ANSWER_MISSING You can forward a quiz while hiding the original author only after choosing an option in the quiz.
/// 500 RANDOM_ID_DUPLICATE You provided a random ID that was already used.
/// 400 RANDOM_ID_INVALID A provided random ID is invalid.
/// 400 REPLY_MESSAGES_TOO_MUCH Each shortcut can contain a maximum of <a href="https://corefork.telegram.org/api/config#quick-reply-messages-limit">appConfig.<code>quick_reply_messages_limit</code></a> messages, the limit was reached.
/// 400 SCHEDULE_BOT_NOT_ALLOWED Bots cannot schedule messages.
/// 400 SCHEDULE_DATE_TOO_LATE You can't schedule a message this far in the future.
/// 400 SCHEDULE_TOO_MUCH There are too many scheduled messages.
/// 400 SEND_AS_PEER_INVALID You can't send messages as the specified peer.
/// 400 SLOWMODE_MULTI_MSGS_DISABLED Slowmode is enabled, you cannot forward multiple messages to this group.
/// 420 SLOWMODE_WAIT_%d Slowmode is enabled in this chat: wait %d seconds before sending another message to this chat.
/// 406 TOPIC_CLOSED This topic was closed, you can't send messages to it anymore.
/// 406 TOPIC_DELETED The specified topic was deleted.
/// 400 USER_BANNED_IN_CHANNEL You're banned from sending messages in supergroups/channels.
/// 403 USER_IS_BLOCKED You were blocked by this user.
/// 400 USER_IS_BOT Bots can't send messages to other bots.
/// 403 VOICE_MESSAGES_FORBIDDEN This user's privacy settings forbid you from sending voice messages.
/// 400 YOU_BLOCKED_USER You blocked this user.
/// See <a href="https://corefork.telegram.org/method/messages.forwardMessages" />
///</summary>
[TlObject(0xd5039208)]
public sealed class RequestForwardMessages : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xd5039208;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether to send messages silently (no notification will be triggered on the destination clients)
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Silent { get; set; }

    ///<summary>
    /// Whether to send the message in background
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Background { get; set; }

    ///<summary>
    /// When forwarding games, whether to include your score in the game
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool WithMyScore { get; set; }

    ///<summary>
    /// Whether to forward messages without quoting the original author
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool DropAuthor { get; set; }

    ///<summary>
    /// Whether to strip captions from media
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool DropMediaCaptions { get; set; }

    ///<summary>
    /// Only for bots, disallows further re-forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Noforwards { get; set; }
    public bool AllowPaidFloodskip { get; set; }

    ///<summary>
    /// Source of messages
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer FromPeer { get; set; }

    ///<summary>
    /// IDs of messages
    ///</summary>
    public TVector<int> Id { get; set; }

    ///<summary>
    /// Random ID to prevent resending of messages
    ///</summary>
    public TVector<long> RandomId { get; set; }

    ///<summary>
    /// Destination peer
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer ToPeer { get; set; }

    ///<summary>
    /// Destination <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a>
    ///</summary>
    public int? TopMsgId { get; set; }

    ///<summary>
    /// Scheduled message date for scheduled messages
    ///</summary>
    public int? ScheduleDate { get; set; }

    ///<summary>
    /// Forward the messages as the specified peer
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer? SendAs { get; set; }

    ///<summary>
    /// Add the messages to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.
    /// See <a href="https://corefork.telegram.org/type/InputQuickReplyShortcut" />
    ///</summary>
    public MyTelegram.Schema.IInputQuickReplyShortcut? QuickReplyShortcut { get; set; }

    public void ComputeFlag()
    {
        if (Silent) { Flags[5] = true; }
        if (Background) { Flags[6] = true; }
        if (WithMyScore) { Flags[8] = true; }
        if (DropAuthor) { Flags[11] = true; }
        if (DropMediaCaptions) { Flags[12] = true; }
        if (Noforwards) { Flags[14] = true; }
        if (AllowPaidFloodskip) { Flags[19] = true; }
        if (/*TopMsgId != 0 && */TopMsgId.HasValue) { Flags[9] = true; }
        if (/*ScheduleDate != 0 && */ScheduleDate.HasValue) { Flags[10] = true; }
        if (SendAs != null) { Flags[13] = true; }
        if (QuickReplyShortcut != null) { Flags[17] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(FromPeer);
        writer.Write(Id);
        writer.Write(RandomId);
        writer.Write(ToPeer);
        if (Flags[9]) { writer.Write(TopMsgId.Value); }
        if (Flags[10]) { writer.Write(ScheduleDate.Value); }
        if (Flags[13]) { writer.Write(SendAs); }
        if (Flags[17]) { writer.Write(QuickReplyShortcut); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[5]) { Silent = true; }
        if (Flags[6]) { Background = true; }
        if (Flags[8]) { WithMyScore = true; }
        if (Flags[11]) { DropAuthor = true; }
        if (Flags[12]) { DropMediaCaptions = true; }
        if (Flags[14]) { Noforwards = true; }
        if (Flags[19]) { AllowPaidFloodskip = true; }
        FromPeer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Id = reader.Read<TVector<int>>();
        RandomId = reader.Read<TVector<long>>();
        ToPeer = reader.Read<MyTelegram.Schema.IInputPeer>();
        if (Flags[9]) { TopMsgId = reader.ReadInt32(); }
        if (Flags[10]) { ScheduleDate = reader.ReadInt32(); }
        if (Flags[13]) { SendAs = reader.Read<MyTelegram.Schema.IInputPeer>(); }
        if (Flags[17]) { QuickReplyShortcut = reader.Read<MyTelegram.Schema.IInputQuickReplyShortcut>(); }
    }
}
