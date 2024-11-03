﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about a group.When updating the <a href="https://corefork.telegram.org/api/peers">local peer database</a>, all fields from the newly received constructor take priority over the old constructor cached locally (including by removing fields that aren't set in the new constructor).See <a href="https://github.com/tdlib/td/blob/a24af0992245f838f2b4b418a0a2d5fa9caa27b5/td/telegram/ChatManager.cpp#L5152">here »</a> for an implementation of the logic to use when updating the <a href="https://corefork.telegram.org/api/peers">local user peer database</a>.
/// See <a href="https://corefork.telegram.org/constructor/chat" />
///</summary>
[TlObject(0x41cbf256)]
public sealed class TChat : MyTelegram.Schema.IChat, ILayeredChat
{
    public uint ConstructorId => 0x41cbf256;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether the current user is the creator of the group
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Creator { get; set; }

    ///<summary>
    /// Whether the current user has left the group
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Left { get; set; }

    ///<summary>
    /// Whether the group was <a href="https://corefork.telegram.org/api/channel">migrated</a>
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Deactivated { get; set; }

    ///<summary>
    /// Whether a group call is currently active
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CallActive { get; set; }

    ///<summary>
    /// Whether there's anyone in the group call
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CallNotEmpty { get; set; }

    ///<summary>
    /// Whether this group is <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">protected</a>, thus does not allow forwarding messages from it
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Noforwards { get; set; }

    ///<summary>
    /// ID of the group, see <a href="https://corefork.telegram.org/api/peers#peer-id">here »</a> for more info
    ///</summary>
    public long Id { get; set; }

    ///<summary>
    /// Title
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// Chat photo
    /// See <a href="https://corefork.telegram.org/type/ChatPhoto" />
    ///</summary>
    public MyTelegram.Schema.IChatPhoto Photo { get; set; }

    ///<summary>
    /// Participant count
    ///</summary>
    public int ParticipantsCount { get; set; }

    ///<summary>
    /// Date of creation of the group
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// Used in basic groups to reorder updates and make sure that all of them were received.
    ///</summary>
    public int Version { get; set; }

    ///<summary>
    /// Means this chat was <a href="https://corefork.telegram.org/api/channel">upgraded</a> to a supergroup
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel? MigratedTo { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/rights">Admin rights</a> of the user in the group
    /// See <a href="https://corefork.telegram.org/type/ChatAdminRights" />
    ///</summary>
    public MyTelegram.Schema.IChatAdminRights? AdminRights { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/rights">Default banned rights</a> of all users in the group
    /// See <a href="https://corefork.telegram.org/type/ChatBannedRights" />
    ///</summary>
    public MyTelegram.Schema.IChatBannedRights? DefaultBannedRights { get; set; }

    public void ComputeFlag()
    {
        if (Creator) { Flags[0] = true; }
        if (Left) { Flags[2] = true; }
        if (Deactivated) { Flags[5] = true; }
        if (CallActive) { Flags[23] = true; }
        if (CallNotEmpty) { Flags[24] = true; }
        if (Noforwards) { Flags[25] = true; }
        if (MigratedTo != null) { Flags[6] = true; }
        if (AdminRights != null) { Flags[14] = true; }
        if (DefaultBannedRights != null) { Flags[18] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Id);
        writer.Write(Title);
        writer.Write(Photo);
        writer.Write(ParticipantsCount);
        writer.Write(Date);
        writer.Write(Version);
        if (Flags[6]) { writer.Write(MigratedTo); }
        if (Flags[14]) { writer.Write(AdminRights); }
        if (Flags[18]) { writer.Write(DefaultBannedRights); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Creator = true; }
        if (Flags[2]) { Left = true; }
        if (Flags[5]) { Deactivated = true; }
        if (Flags[23]) { CallActive = true; }
        if (Flags[24]) { CallNotEmpty = true; }
        if (Flags[25]) { Noforwards = true; }
        Id = reader.ReadInt64();
        Title = reader.ReadString();
        Photo = reader.Read<MyTelegram.Schema.IChatPhoto>();
        ParticipantsCount = reader.ReadInt32();
        Date = reader.ReadInt32();
        Version = reader.ReadInt32();
        if (Flags[6]) { MigratedTo = reader.Read<MyTelegram.Schema.IInputChannel>(); }
        if (Flags[14]) { AdminRights = reader.Read<MyTelegram.Schema.IChatAdminRights>(); }
        if (Flags[18]) { DefaultBannedRights = reader.Read<MyTelegram.Schema.IChatBannedRights>(); }
    }
}