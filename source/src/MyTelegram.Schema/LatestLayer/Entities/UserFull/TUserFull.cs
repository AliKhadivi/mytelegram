﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Extended user info
/// See <a href="https://corefork.telegram.org/constructor/userFull" />
///</summary>
[TlObject(0xcc997720)]
public sealed class TUserFull : IUserFull
{
    public uint ConstructorId => 0xcc997720;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether you have blocked this user
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Blocked { get; set; }

    ///<summary>
    /// Whether this user can make VoIP calls
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool PhoneCallsAvailable { get; set; }

    ///<summary>
    /// Whether this user's privacy settings allow you to call them
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool PhoneCallsPrivate { get; set; }

    ///<summary>
    /// Whether you can pin messages in the chat with this user, you can do this only for a chat with yourself
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CanPinMessage { get; set; }

    ///<summary>
    /// Whether <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a> are available
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool HasScheduled { get; set; }

    ///<summary>
    /// Whether the user can receive video calls
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool VideoCallsAvailable { get; set; }

    ///<summary>
    /// Whether this user doesn't allow sending voice messages in a private chat with them
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool VoiceMessagesForbidden { get; set; }

    ///<summary>
    /// Whether the <a href="https://corefork.telegram.org/api/translation">real-time chat translation popup</a> should be hidden.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool TranslationsDisabled { get; set; }

    ///<summary>
    /// Whether this user has some <a href="https://corefork.telegram.org/api/stories#pinned-or-archived-stories">pinned stories</a>.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool StoriesPinnedAvailable { get; set; }

    ///<summary>
    /// Whether we've <a href="https://corefork.telegram.org/api/block">blocked this user, preventing them from seeing our stories »</a>.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool BlockedMyStoriesFrom { get; set; }

    ///<summary>
    /// Whether the other user has chosen a custom wallpaper for us using <a href="https://corefork.telegram.org/method/messages.setChatWallPaper">messages.setChatWallPaper</a> and the <code>for_both</code> flag, see <a href="https://corefork.telegram.org/api/wallpapers#installing-wallpapers-in-a-specific-chat-or-channel">here »</a> for more info.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool WallpaperOverridden { get; set; }
    public bool ContactRequirePremium { get; set; }
    public bool ReadDatesPrivate { get; set; }
    public BitArray Flags2 { get; set; } = new BitArray(32);
    public bool SponsoredEnabled { get; set; }

    ///<summary>
    /// User ID
    ///</summary>
    public long Id { get; set; }

    ///<summary>
    /// Bio of the user
    ///</summary>
    public string? About { get; set; }

    ///<summary>
    /// Peer settings
    /// See <a href="https://corefork.telegram.org/type/PeerSettings" />
    ///</summary>
    public MyTelegram.Schema.IPeerSettings Settings { get; set; }

    ///<summary>
    /// Personal profile photo, to be shown instead of <code>profile_photo</code>.
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    public MyTelegram.Schema.IPhoto? PersonalPhoto { get; set; }

    ///<summary>
    /// Profile photo
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    public MyTelegram.Schema.IPhoto? ProfilePhoto { get; set; }

    ///<summary>
    /// Fallback profile photo, displayed if no photo is present in <code>profile_photo</code> or <code>personal_photo</code>, due to privacy settings.
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    public MyTelegram.Schema.IPhoto? FallbackPhoto { get; set; }

    ///<summary>
    /// Notification settings
    /// See <a href="https://corefork.telegram.org/type/PeerNotifySettings" />
    ///</summary>
    public MyTelegram.Schema.IPeerNotifySettings NotifySettings { get; set; }

    ///<summary>
    /// For bots, info about the bot (bot commands, etc)
    /// See <a href="https://corefork.telegram.org/type/BotInfo" />
    ///</summary>
    public MyTelegram.Schema.IBotInfo? BotInfo { get; set; }

    ///<summary>
    /// Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a>
    ///</summary>
    public int? PinnedMsgId { get; set; }

    ///<summary>
    /// Chats in common with this user
    ///</summary>
    public int CommonChatsCount { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a>
    ///</summary>
    public int? FolderId { get; set; }

    ///<summary>
    /// Time To Live of all messages in this chat; once a message is this many seconds old, it must be deleted.
    ///</summary>
    public int? TtlPeriod { get; set; }

    ///<summary>
    /// Emoji associated with chat theme
    ///</summary>
    public string? ThemeEmoticon { get; set; }

    ///<summary>
    /// Anonymized text to be shown instead of the user's name on forwarded messages
    ///</summary>
    public string? PrivateForwardName { get; set; }

    ///<summary>
    /// A <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">suggested set of administrator rights</a> for the bot, to be shown when adding the bot as admin to a group, see <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">here for more info on how to handle them »</a>.
    /// See <a href="https://corefork.telegram.org/type/ChatAdminRights" />
    ///</summary>
    public MyTelegram.Schema.IChatAdminRights? BotGroupAdminRights { get; set; }

    ///<summary>
    /// A <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">suggested set of administrator rights</a> for the bot, to be shown when adding the bot as admin to a channel, see <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">here for more info on how to handle them »</a>.
    /// See <a href="https://corefork.telegram.org/type/ChatAdminRights" />
    ///</summary>
    public MyTelegram.Schema.IChatAdminRights? BotBroadcastAdminRights { get; set; }

    ///<summary>
    /// Telegram Premium subscriptions gift options
    ///</summary>
    public TVector<MyTelegram.Schema.IPremiumGiftOption>? PremiumGifts { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/wallpapers">Wallpaper</a> to use in the private chat with the user.
    /// See <a href="https://corefork.telegram.org/type/WallPaper" />
    ///</summary>
    public MyTelegram.Schema.IWallPaper? Wallpaper { get; set; }

    ///<summary>
    /// Active <a href="https://corefork.telegram.org/api/stories">stories »</a>
    /// See <a href="https://corefork.telegram.org/type/PeerStories" />
    ///</summary>
    public MyTelegram.Schema.IPeerStories? Stories { get; set; }
    public MyTelegram.Schema.IBusinessWorkHours? BusinessWorkHours { get; set; }
    public MyTelegram.Schema.IBusinessLocation? BusinessLocation { get; set; }
    public MyTelegram.Schema.IBusinessGreetingMessage? BusinessGreetingMessage { get; set; }
    public MyTelegram.Schema.IBusinessAwayMessage? BusinessAwayMessage { get; set; }
    public MyTelegram.Schema.IBusinessIntro? BusinessIntro { get; set; }
    public MyTelegram.Schema.IBirthday? Birthday { get; set; }
    public long? PersonalChannelId { get; set; }
    public int? PersonalChannelMessage { get; set; }

    public void ComputeFlag()
    {
        if (Blocked) { Flags[0] = true; }
        if (PhoneCallsAvailable) { Flags[4] = true; }
        if (PhoneCallsPrivate) { Flags[5] = true; }
        if (CanPinMessage) { Flags[7] = true; }
        if (HasScheduled) { Flags[12] = true; }
        if (VideoCallsAvailable) { Flags[13] = true; }
        if (VoiceMessagesForbidden) { Flags[20] = true; }
        if (TranslationsDisabled) { Flags[23] = true; }
        if (StoriesPinnedAvailable) { Flags[26] = true; }
        if (BlockedMyStoriesFrom) { Flags[27] = true; }
        if (WallpaperOverridden) { Flags[28] = true; }
        if (ContactRequirePremium) { Flags[29] = true; }
        if (ReadDatesPrivate) { Flags[30] = true; }
        if (SponsoredEnabled) { Flags2[7] = true; }
        if (About != null) { Flags[1] = true; }
        if (PersonalPhoto != null) { Flags[21] = true; }
        if (ProfilePhoto != null) { Flags[2] = true; }
        if (FallbackPhoto != null) { Flags[22] = true; }
        if (BotInfo != null) { Flags[3] = true; }
        if (/*PinnedMsgId != 0 && */PinnedMsgId.HasValue) { Flags[6] = true; }
        if (/*FolderId != 0 && */FolderId.HasValue) { Flags[11] = true; }
        if (/*TtlPeriod != 0 && */TtlPeriod.HasValue) { Flags[14] = true; }
        if (ThemeEmoticon != null) { Flags[15] = true; }
        if (PrivateForwardName != null) { Flags[16] = true; }
        if (BotGroupAdminRights != null) { Flags[17] = true; }
        if (BotBroadcastAdminRights != null) { Flags[18] = true; }
        if (PremiumGifts?.Count > 0) { Flags[19] = true; }
        if (Wallpaper != null) { Flags[24] = true; }
        if (Stories != null) { Flags[25] = true; }
        if (BusinessWorkHours != null) { Flags2[0] = true; }
        if (BusinessLocation != null) { Flags2[1] = true; }
        if (BusinessGreetingMessage != null) { Flags2[2] = true; }
        if (BusinessAwayMessage != null) { Flags2[3] = true; }
        if (BusinessIntro != null) { Flags2[4] = true; }
        if (Birthday != null) { Flags2[5] = true; }
        if (/*PersonalChannelId != 0 &&*/ PersonalChannelId.HasValue) { Flags2[6] = true; }
        if (/*PersonalChannelMessage != 0 && */PersonalChannelMessage.HasValue) { Flags2[6] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Flags2);
        writer.Write(Id);
        if (Flags[1]) { writer.Write(About); }
        writer.Write(Settings);
        if (Flags[21]) { writer.Write(PersonalPhoto); }
        if (Flags[2]) { writer.Write(ProfilePhoto); }
        if (Flags[22]) { writer.Write(FallbackPhoto); }
        writer.Write(NotifySettings);
        if (Flags[3]) { writer.Write(BotInfo); }
        if (Flags[6]) { writer.Write(PinnedMsgId.Value); }
        writer.Write(CommonChatsCount);
        if (Flags[11]) { writer.Write(FolderId.Value); }
        if (Flags[14]) { writer.Write(TtlPeriod.Value); }
        if (Flags[15]) { writer.Write(ThemeEmoticon); }
        if (Flags[16]) { writer.Write(PrivateForwardName); }
        if (Flags[17]) { writer.Write(BotGroupAdminRights); }
        if (Flags[18]) { writer.Write(BotBroadcastAdminRights); }
        if (Flags[19]) { writer.Write(PremiumGifts); }
        if (Flags[24]) { writer.Write(Wallpaper); }
        if (Flags[25]) { writer.Write(Stories); }
        if (Flags2[0]) { writer.Write(BusinessWorkHours); }
        if (Flags2[1]) { writer.Write(BusinessLocation); }
        if (Flags2[2]) { writer.Write(BusinessGreetingMessage); }
        if (Flags2[3]) { writer.Write(BusinessAwayMessage); }
        if (Flags2[4]) { writer.Write(BusinessIntro); }
        if (Flags2[5]) { writer.Write(Birthday); }
        if (Flags2[6]) { writer.Write(PersonalChannelId.Value); }
        if (Flags2[6]) { writer.Write(PersonalChannelMessage.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Blocked = true; }
        if (Flags[4]) { PhoneCallsAvailable = true; }
        if (Flags[5]) { PhoneCallsPrivate = true; }
        if (Flags[7]) { CanPinMessage = true; }
        if (Flags[12]) { HasScheduled = true; }
        if (Flags[13]) { VideoCallsAvailable = true; }
        if (Flags[20]) { VoiceMessagesForbidden = true; }
        if (Flags[23]) { TranslationsDisabled = true; }
        if (Flags[26]) { StoriesPinnedAvailable = true; }
        if (Flags[27]) { BlockedMyStoriesFrom = true; }
        if (Flags[28]) { WallpaperOverridden = true; }
        if (Flags[29]) { ContactRequirePremium = true; }
        if (Flags[30]) { ReadDatesPrivate = true; }
        Flags2 = reader.ReadBitArray();
        if (Flags2[7]) { SponsoredEnabled = true; }
        Id = reader.ReadInt64();
        if (Flags[1]) { About = reader.ReadString(); }
        Settings = reader.Read<MyTelegram.Schema.IPeerSettings>();
        if (Flags[21]) { PersonalPhoto = reader.Read<MyTelegram.Schema.IPhoto>(); }
        if (Flags[2]) { ProfilePhoto = reader.Read<MyTelegram.Schema.IPhoto>(); }
        if (Flags[22]) { FallbackPhoto = reader.Read<MyTelegram.Schema.IPhoto>(); }
        NotifySettings = reader.Read<MyTelegram.Schema.IPeerNotifySettings>();
        if (Flags[3]) { BotInfo = reader.Read<MyTelegram.Schema.IBotInfo>(); }
        if (Flags[6]) { PinnedMsgId = reader.ReadInt32(); }
        CommonChatsCount = reader.ReadInt32();
        if (Flags[11]) { FolderId = reader.ReadInt32(); }
        if (Flags[14]) { TtlPeriod = reader.ReadInt32(); }
        if (Flags[15]) { ThemeEmoticon = reader.ReadString(); }
        if (Flags[16]) { PrivateForwardName = reader.ReadString(); }
        if (Flags[17]) { BotGroupAdminRights = reader.Read<MyTelegram.Schema.IChatAdminRights>(); }
        if (Flags[18]) { BotBroadcastAdminRights = reader.Read<MyTelegram.Schema.IChatAdminRights>(); }
        if (Flags[19]) { PremiumGifts = reader.Read<TVector<MyTelegram.Schema.IPremiumGiftOption>>(); }
        if (Flags[24]) { Wallpaper = reader.Read<MyTelegram.Schema.IWallPaper>(); }
        if (Flags[25]) { Stories = reader.Read<MyTelegram.Schema.IPeerStories>(); }
        if (Flags2[0]) { BusinessWorkHours = reader.Read<MyTelegram.Schema.IBusinessWorkHours>(); }
        if (Flags2[1]) { BusinessLocation = reader.Read<MyTelegram.Schema.IBusinessLocation>(); }
        if (Flags2[2]) { BusinessGreetingMessage = reader.Read<MyTelegram.Schema.IBusinessGreetingMessage>(); }
        if (Flags2[3]) { BusinessAwayMessage = reader.Read<MyTelegram.Schema.IBusinessAwayMessage>(); }
        if (Flags2[4]) { BusinessIntro = reader.Read<MyTelegram.Schema.IBusinessIntro>(); }
        if (Flags2[5]) { Birthday = reader.Read<MyTelegram.Schema.IBirthday>(); }
        if (Flags2[6]) { PersonalChannelId = reader.ReadInt64(); }
        if (Flags2[6]) { PersonalChannelMessage = reader.ReadInt32(); }
    }
}