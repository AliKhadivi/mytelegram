﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about bots (available bot commands, etc)
/// See <a href="https://corefork.telegram.org/constructor/botInfo" />
///</summary>
[TlObject(0x82437e74)]
public sealed class TBotInfo : IBotInfo
{
    public uint ConstructorId => 0x82437e74;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// If set, the bot has some <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">preview medias for the configured Main Mini App, see here »</a> for more info on Main Mini App preview medias.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool HasPreviewMedias { get; set; }

    ///<summary>
    /// ID of the bot
    ///</summary>
    public long? UserId { get; set; }

    ///<summary>
    /// Description of the bot
    ///</summary>
    public string? Description { get; set; }

    ///<summary>
    /// Description photo
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    public MyTelegram.Schema.IPhoto? DescriptionPhoto { get; set; }

    ///<summary>
    /// Description animation in MPEG4 format
    /// See <a href="https://corefork.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument? DescriptionDocument { get; set; }

    ///<summary>
    /// Bot commands that can be used in the chat
    ///</summary>
    public TVector<MyTelegram.Schema.IBotCommand>? Commands { get; set; }

    ///<summary>
    /// Indicates the action to execute when pressing the in-UI menu button for bots
    /// See <a href="https://corefork.telegram.org/type/BotMenuButton" />
    ///</summary>
    public MyTelegram.Schema.IBotMenuButton? MenuButton { get; set; }
    public string? PrivacyPolicyUrl { get; set; }

    public void ComputeFlag()
    {
        if (HasPreviewMedias) { Flags[6] = true; }
        if (/*UserId != 0 &&*/ UserId.HasValue) { Flags[0] = true; }
        if (Description != null) { Flags[1] = true; }
        if (DescriptionPhoto != null) { Flags[4] = true; }
        if (DescriptionDocument != null) { Flags[5] = true; }
        if (Commands?.Count > 0) { Flags[2] = true; }
        if (MenuButton != null) { Flags[3] = true; }
        if (PrivacyPolicyUrl != null) { Flags[7] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[0]) { writer.Write(UserId.Value); }
        if (Flags[1]) { writer.Write(Description); }
        if (Flags[4]) { writer.Write(DescriptionPhoto); }
        if (Flags[5]) { writer.Write(DescriptionDocument); }
        if (Flags[2]) { writer.Write(Commands); }
        if (Flags[3]) { writer.Write(MenuButton); }
        if (Flags[7]) { writer.Write(PrivacyPolicyUrl); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[6]) { HasPreviewMedias = true; }
        if (Flags[0]) { UserId = reader.ReadInt64(); }
        if (Flags[1]) { Description = reader.ReadString(); }
        if (Flags[4]) { DescriptionPhoto = reader.Read<MyTelegram.Schema.IPhoto>(); }
        if (Flags[5]) { DescriptionDocument = reader.Read<MyTelegram.Schema.IDocument>(); }
        if (Flags[2]) { Commands = reader.Read<TVector<MyTelegram.Schema.IBotCommand>>(); }
        if (Flags[3]) { MenuButton = reader.Read<MyTelegram.Schema.IBotMenuButton>(); }
        if (Flags[7]) { PrivacyPolicyUrl = reader.ReadString(); }
    }
}