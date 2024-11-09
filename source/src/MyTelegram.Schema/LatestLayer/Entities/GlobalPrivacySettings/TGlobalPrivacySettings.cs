﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Global privacy settings
/// See <a href="https://corefork.telegram.org/constructor/globalPrivacySettings" />
///</summary>
[TlObject(0x734c4ccb)]
public sealed class TGlobalPrivacySettings : IGlobalPrivacySettings
{
    public uint ConstructorId => 0x734c4ccb;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether to archive and mute new chats from non-contacts
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ArchiveAndMuteNewNoncontactPeers { get; set; }

    ///<summary>
    /// Whether unmuted chats will be kept in the Archive chat list when they get a new message.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool KeepArchivedUnmuted { get; set; }

    ///<summary>
    /// Whether unmuted chats that are always included or pinned in a <a href="https://corefork.telegram.org/api/folders">folder</a>, will be kept in the Archive chat list when they get a new message. Ignored if <code>keep_archived_unmuted</code> is set.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool KeepArchivedFolders { get; set; }

    ///<summary>
    /// If this flag is set, the <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyStatusTimestamp">inputPrivacyKeyStatusTimestamp</a> key will also apply to the ability to use <a href="https://corefork.telegram.org/method/messages.getOutboxReadDate">messages.getOutboxReadDate</a> on messages sent to us. <br>Meaning, users that cannot see <em>our</em> exact last online date due to the current value of the <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyStatusTimestamp">inputPrivacyKeyStatusTimestamp</a> key will receive a <code>403 USER_PRIVACY_RESTRICTED</code> error when invoking <a href="https://corefork.telegram.org/method/messages.getOutboxReadDate">messages.getOutboxReadDate</a> to fetch the exact read date of a message they sent to us. <br>The <a href="https://corefork.telegram.org/constructor/userFull">userFull</a>.<code>read_dates_private</code> flag will be set for users that have this flag enabled.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool HideReadMarks { get; set; }

    ///<summary>
    /// If set, only users that have a premium account, are in our contact list, or already have a private chat with us can write to us; a <code>403 PRIVACY_PREMIUM_REQUIRED</code> error will be emitted otherwise.  <br>The <a href="https://corefork.telegram.org/constructor/userFull">userFull</a>.<code>contact_require_premium</code> flag will be set for users that have this flag enabled.  <br>To check whether we can write to a user with this flag enabled, if we haven't yet cached all the required information (for example we don't have the <a href="https://corefork.telegram.org/constructor/userFull">userFull</a> or history of all users while displaying the chat list in the sharing UI) the <a href="https://corefork.telegram.org/method/users.getIsPremiumRequiredToContact">users.getIsPremiumRequiredToContact</a> method may be invoked, passing the list of users currently visible in the UI, returning a list of booleans that directly specify whether we can or cannot write to each user. <br><a href="https://corefork.telegram.org/api/premium">Premium</a> users only, non-Premium users will receive a <code>PREMIUM_ACCOUNT_REQUIRED</code> error when trying to enable this flag.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool NewNoncontactPeersRequirePremium { get; set; }

    public void ComputeFlag()
    {
        if (ArchiveAndMuteNewNoncontactPeers) { Flags[0] = true; }
        if (KeepArchivedUnmuted) { Flags[1] = true; }
        if (KeepArchivedFolders) { Flags[2] = true; }
        if (HideReadMarks) { Flags[3] = true; }
        if (NewNoncontactPeersRequirePremium) { Flags[4] = true; }
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
        if (Flags[0]) { ArchiveAndMuteNewNoncontactPeers = true; }
        if (Flags[1]) { KeepArchivedUnmuted = true; }
        if (Flags[2]) { KeepArchivedFolders = true; }
        if (Flags[3]) { HideReadMarks = true; }
        if (Flags[4]) { NewNoncontactPeersRequirePremium = true; }
    }
}