﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stories;

///<summary>
/// Uploads a <a href="https://corefork.telegram.org/api/stories">Telegram Story</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 IMAGE_PROCESS_FAILED Failure while processing image.
/// 400 MEDIA_EMPTY The provided media object is invalid.
/// 400 MEDIA_FILE_INVALID The specified media file is invalid.
/// 400 MEDIA_TYPE_INVALID The specified media type cannot be used in stories.
/// 400 MEDIA_VIDEO_STORY_MISSING &nbsp;
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 PREMIUM_ACCOUNT_REQUIRED A premium account is required to execute this action.
/// 400 STORIES_TOO_MUCH You have hit the maximum active stories limit as specified by the <a href="https://corefork.telegram.org/api/config#stories-sent-weekly-limit-default"><code>story_expiring_limit_*</code> client configuration parameters</a>: you should buy a <a href="https://corefork.telegram.org/api/premium">Premium</a> subscription, delete an active story, or wait for the oldest story to expire.
/// 400 STORY_PERIOD_INVALID The specified story period is invalid for this account.
/// 400 VENUE_ID_INVALID &nbsp;
/// See <a href="https://corefork.telegram.org/method/stories.sendStory" />
///</summary>
[TlObject(0xbcb73644)]
public sealed class RequestSendStory : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xbcb73644;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether to add the story to the profile automatically upon expiration. If not set, the story will only be added to the archive, see <a href="https://corefork.telegram.org/api/stories">here »</a> for more info.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Pinned { get; set; }

    ///<summary>
    /// If set, disables forwards, screenshots, and downloads.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Noforwards { get; set; }

    ///<summary>
    /// The peer to send the story as.
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// The story media.
    /// See <a href="https://corefork.telegram.org/type/InputMedia" />
    ///</summary>
    public MyTelegram.Schema.IInputMedia Media { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/stories#media-areas">Media areas</a> associated to the story, see <a href="https://corefork.telegram.org/api/stories#media-areas">here »</a> for more info.
    ///</summary>
    public TVector<MyTelegram.Schema.IMediaArea>? MediaAreas { get; set; }

    ///<summary>
    /// Story caption.
    ///</summary>
    public string? Caption { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a>
    ///</summary>
    public TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/privacy">Privacy rules</a> for the story, indicating who can or can't view the story.
    ///</summary>
    public TVector<MyTelegram.Schema.IInputPrivacyRule> PrivacyRules { get; set; }

    ///<summary>
    /// Unique client message ID required to prevent message resending.
    ///</summary>
    public long RandomId { get; set; }

    ///<summary>
    /// Period after which the story is moved to archive (and to the profile if <code>pinned</code> is set), in seconds; must be one of <code>6 * 3600</code>, <code>12 * 3600</code>, <code>86400</code>, or <code>2 * 86400</code> for Telegram Premium users, and <code>86400</code> otherwise.
    ///</summary>
    public int? Period { get; set; }

    public void ComputeFlag()
    {
        if (Pinned) { Flags[2] = true; }
        if (Noforwards) { Flags[4] = true; }
        if (MediaAreas?.Count > 0) { Flags[5] = true; }
        if (Caption != null) { Flags[0] = true; }
        if (Entities?.Count > 0) { Flags[1] = true; }
        if (/*Period != 0 && */Period.HasValue) { Flags[3] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(Media);
        if (Flags[5]) { writer.Write(MediaAreas); }
        if (Flags[0]) { writer.Write(Caption); }
        if (Flags[1]) { writer.Write(Entities); }
        writer.Write(PrivacyRules);
        writer.Write(RandomId);
        if (Flags[3]) { writer.Write(Period.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[2]) { Pinned = true; }
        if (Flags[4]) { Noforwards = true; }
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Media = reader.Read<MyTelegram.Schema.IInputMedia>();
        if (Flags[5]) { MediaAreas = reader.Read<TVector<MyTelegram.Schema.IMediaArea>>(); }
        if (Flags[0]) { Caption = reader.ReadString(); }
        if (Flags[1]) { Entities = reader.Read<TVector<MyTelegram.Schema.IMessageEntity>>(); }
        PrivacyRules = reader.Read<TVector<MyTelegram.Schema.IInputPrivacyRule>>();
        RandomId = reader.ReadInt64();
        if (Flags[3]) { Period = reader.ReadInt32(); }
    }
}