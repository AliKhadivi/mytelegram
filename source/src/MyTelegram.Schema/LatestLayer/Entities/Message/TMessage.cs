﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A message
/// See <a href="https://corefork.telegram.org/constructor/message" />
///</summary>
[TlObject(0x2357bf25)]
public sealed class TMessage : IMessage
{
    public uint ConstructorId => 0x2357bf25;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Is this an outgoing message
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Out { get; set; }

    ///<summary>
    /// Whether we were <a href="https://corefork.telegram.org/api/mentions">mentioned</a> in this message
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Mentioned { get; set; }

    ///<summary>
    /// Whether there are unread media attachments in this message
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool MediaUnread { get; set; }

    ///<summary>
    /// Whether this is a silent message (no notification triggered)
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Silent { get; set; }

    ///<summary>
    /// Whether this is a channel post
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Post { get; set; }

    ///<summary>
    /// Whether this is a <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled message</a>
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool FromScheduled { get; set; }

    ///<summary>
    /// This is a legacy message: it has to be refetched with the new layer
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Legacy { get; set; }

    ///<summary>
    /// Whether the message should be shown as not modified to the user, even if an edit date is present
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool EditHide { get; set; }

    ///<summary>
    /// Whether this message is <a href="https://corefork.telegram.org/api/pin">pinned</a>
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Pinned { get; set; }

    ///<summary>
    /// Whether this message is <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">protected</a> and thus cannot be forwarded; clients should also prevent users from saving attached media (i.e. videos should only be streamed, photos should be kept in RAM, et cetera).
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Noforwards { get; set; }

    ///<summary>
    /// If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool InvertMedia { get; set; }
    public BitArray Flags2 { get; set; } = new BitArray(32);
    public bool Offline { get; set; }

    ///<summary>
    /// ID of the message
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// ID of the sender of the message
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer? FromId { get; set; }
    public int? FromBoostsApplied { get; set; }

    ///<summary>
    /// Peer ID, the chat where this message was sent
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer PeerId { get; set; }

    ///<summary>
    /// Messages fetched from a <a href="https://corefork.telegram.org/api/saved-messages">saved messages dialog »</a> will have <code>peer</code>=<a href="https://corefork.telegram.org/constructor/inputPeerSelf">inputPeerSelf</a> and the <code>saved_peer_id</code> flag set to the ID of the saved dialog.<br>
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer? SavedPeerId { get; set; }

    ///<summary>
    /// Info about forwarded messages
    /// See <a href="https://corefork.telegram.org/type/MessageFwdHeader" />
    ///</summary>
    public MyTelegram.Schema.IMessageFwdHeader? FwdFrom { get; set; }

    ///<summary>
    /// ID of the inline bot that generated the message
    ///</summary>
    public long? ViaBotId { get; set; }
    public long? ViaBusinessBotId { get; set; }

    ///<summary>
    /// Reply information
    /// See <a href="https://corefork.telegram.org/type/MessageReplyHeader" />
    ///</summary>
    public MyTelegram.Schema.IMessageReplyHeader? ReplyTo { get; set; }

    ///<summary>
    /// Date of the message
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// The message
    ///</summary>
    public string Message { get; set; }

    ///<summary>
    /// Media attachment
    /// See <a href="https://corefork.telegram.org/type/MessageMedia" />
    ///</summary>
    public MyTelegram.Schema.IMessageMedia? Media { get; set; }

    ///<summary>
    /// Reply markup (bot/inline keyboards)
    /// See <a href="https://corefork.telegram.org/type/ReplyMarkup" />
    ///</summary>
    public MyTelegram.Schema.IReplyMarkup? ReplyMarkup { get; set; }

    ///<summary>
    /// Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text
    ///</summary>
    public TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }

    ///<summary>
    /// View count for channel posts
    ///</summary>
    public int? Views { get; set; }

    ///<summary>
    /// Forward counter
    ///</summary>
    public int? Forwards { get; set; }

    ///<summary>
    /// Info about <a href="https://corefork.telegram.org/api/threads">post comments (for channels) or message replies (for groups)</a>
    /// See <a href="https://corefork.telegram.org/type/MessageReplies" />
    ///</summary>
    public MyTelegram.Schema.IMessageReplies? Replies { get; set; }

    ///<summary>
    /// Last edit date of this message
    ///</summary>
    public int? EditDate { get; set; }

    ///<summary>
    /// Name of the author of this message for channel posts (with signatures enabled)
    ///</summary>
    public string? PostAuthor { get; set; }

    ///<summary>
    /// Multiple media messages sent using <a href="https://corefork.telegram.org/method/messages.sendMultiMedia">messages.sendMultiMedia</a> with the same grouped ID indicate an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or media group</a>
    ///</summary>
    public long? GroupedId { get; set; }

    ///<summary>
    /// Reactions to this message
    /// See <a href="https://corefork.telegram.org/type/MessageReactions" />
    ///</summary>
    public MyTelegram.Schema.IMessageReactions? Reactions { get; set; }

    ///<summary>
    /// Contains the reason why access to this message must be restricted.
    ///</summary>
    public TVector<MyTelegram.Schema.IRestrictionReason>? RestrictionReason { get; set; }

    ///<summary>
    /// Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.
    ///</summary>
    public int? TtlPeriod { get; set; }
    public int? QuickReplyShortcutId { get; set; }

    public void ComputeFlag()
    {
        if (Out) { Flags[1] = true; }
        if (Mentioned) { Flags[4] = true; }
        if (MediaUnread) { Flags[5] = true; }
        if (Silent) { Flags[13] = true; }
        if (Post) { Flags[14] = true; }
        if (FromScheduled) { Flags[18] = true; }
        if (Legacy) { Flags[19] = true; }
        if (EditHide) { Flags[21] = true; }
        if (Pinned) { Flags[24] = true; }
        if (Noforwards) { Flags[26] = true; }
        if (InvertMedia) { Flags[27] = true; }
        if (Offline) { Flags2[1] = true; }
        if (FromId != null) { Flags[8] = true; }
        if (/*FromBoostsApplied != 0 && */FromBoostsApplied.HasValue) { Flags[29] = true; }
        if (SavedPeerId != null) { Flags[28] = true; }
        if (FwdFrom != null) { Flags[2] = true; }
        if (/*ViaBotId != 0 &&*/ ViaBotId.HasValue) { Flags[11] = true; }
        if (/*ViaBusinessBotId != 0 &&*/ ViaBusinessBotId.HasValue) { Flags2[0] = true; }
        if (ReplyTo != null) { Flags[3] = true; }
        if (Media != null) { Flags[9] = true; }
        if (ReplyMarkup != null) { Flags[6] = true; }
        if (Entities?.Count > 0) { Flags[7] = true; }
        if (/*Views != 0 && */Views.HasValue) { Flags[10] = true; }
        if (/*Forwards != 0 && */Forwards.HasValue) { Flags[10] = true; }
        if (Replies != null) { Flags[23] = true; }
        if (/*EditDate != 0 && */EditDate.HasValue) { Flags[15] = true; }
        if (PostAuthor != null) { Flags[16] = true; }
        if (/*GroupedId != 0 &&*/ GroupedId.HasValue) { Flags[17] = true; }
        if (Reactions != null) { Flags[20] = true; }
        if (RestrictionReason?.Count > 0) { Flags[22] = true; }
        if (/*TtlPeriod != 0 && */TtlPeriod.HasValue) { Flags[25] = true; }
        if (/*QuickReplyShortcutId != 0 && */QuickReplyShortcutId.HasValue) { Flags[30] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Flags2);
        writer.Write(Id);
        if (Flags[8]) { writer.Write(FromId); }
        if (Flags[29]) { writer.Write(FromBoostsApplied.Value); }
        writer.Write(PeerId);
        if (Flags[28]) { writer.Write(SavedPeerId); }
        if (Flags[2]) { writer.Write(FwdFrom); }
        if (Flags[11]) { writer.Write(ViaBotId.Value); }
        if (Flags2[0]) { writer.Write(ViaBusinessBotId.Value); }
        if (Flags[3]) { writer.Write(ReplyTo); }
        writer.Write(Date);
        writer.Write(Message);
        if (Flags[9]) { writer.Write(Media); }
        if (Flags[6]) { writer.Write(ReplyMarkup); }
        if (Flags[7]) { writer.Write(Entities); }
        if (Flags[10]) { writer.Write(Views.Value); }
        if (Flags[10]) { writer.Write(Forwards.Value); }
        if (Flags[23]) { writer.Write(Replies); }
        if (Flags[15]) { writer.Write(EditDate.Value); }
        if (Flags[16]) { writer.Write(PostAuthor); }
        if (Flags[17]) { writer.Write(GroupedId.Value); }
        if (Flags[20]) { writer.Write(Reactions); }
        if (Flags[22]) { writer.Write(RestrictionReason); }
        if (Flags[25]) { writer.Write(TtlPeriod.Value); }
        if (Flags[30]) { writer.Write(QuickReplyShortcutId.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[1]) { Out = true; }
        if (Flags[4]) { Mentioned = true; }
        if (Flags[5]) { MediaUnread = true; }
        if (Flags[13]) { Silent = true; }
        if (Flags[14]) { Post = true; }
        if (Flags[18]) { FromScheduled = true; }
        if (Flags[19]) { Legacy = true; }
        if (Flags[21]) { EditHide = true; }
        if (Flags[24]) { Pinned = true; }
        if (Flags[26]) { Noforwards = true; }
        if (Flags[27]) { InvertMedia = true; }
        Flags2 = reader.ReadBitArray();
        if (Flags2[1]) { Offline = true; }
        Id = reader.ReadInt32();
        if (Flags[8]) { FromId = reader.Read<MyTelegram.Schema.IPeer>(); }
        if (Flags[29]) { FromBoostsApplied = reader.ReadInt32(); }
        PeerId = reader.Read<MyTelegram.Schema.IPeer>();
        if (Flags[28]) { SavedPeerId = reader.Read<MyTelegram.Schema.IPeer>(); }
        if (Flags[2]) { FwdFrom = reader.Read<MyTelegram.Schema.IMessageFwdHeader>(); }
        if (Flags[11]) { ViaBotId = reader.ReadInt64(); }
        if (Flags2[0]) { ViaBusinessBotId = reader.ReadInt64(); }
        if (Flags[3]) { ReplyTo = reader.Read<MyTelegram.Schema.IMessageReplyHeader>(); }
        Date = reader.ReadInt32();
        Message = reader.ReadString();
        if (Flags[9]) { Media = reader.Read<MyTelegram.Schema.IMessageMedia>(); }
        if (Flags[6]) { ReplyMarkup = reader.Read<MyTelegram.Schema.IReplyMarkup>(); }
        if (Flags[7]) { Entities = reader.Read<TVector<MyTelegram.Schema.IMessageEntity>>(); }
        if (Flags[10]) { Views = reader.ReadInt32(); }
        if (Flags[10]) { Forwards = reader.ReadInt32(); }
        if (Flags[23]) { Replies = reader.Read<MyTelegram.Schema.IMessageReplies>(); }
        if (Flags[15]) { EditDate = reader.ReadInt32(); }
        if (Flags[16]) { PostAuthor = reader.ReadString(); }
        if (Flags[17]) { GroupedId = reader.ReadInt64(); }
        if (Flags[20]) { Reactions = reader.Read<MyTelegram.Schema.IMessageReactions>(); }
        if (Flags[22]) { RestrictionReason = reader.Read<TVector<MyTelegram.Schema.IRestrictionReason>>(); }
        if (Flags[25]) { TtlPeriod = reader.ReadInt32(); }
        if (Flags[30]) { QuickReplyShortcutId = reader.ReadInt32(); }
    }
}