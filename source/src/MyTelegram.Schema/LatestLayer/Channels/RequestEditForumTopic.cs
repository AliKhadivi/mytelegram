﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Edit <a href="https://corefork.telegram.org/api/forum">forum topic</a>; requires <a href="https://corefork.telegram.org/api/rights"><code>manage_topics</code> rights</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_FORUM_MISSING This supergroup is not a forum.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 403 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 400 DOCUMENT_INVALID The specified document is invalid.
/// 400 GENERAL_MODIFY_ICON_FORBIDDEN You can't modify the icon of the "General" topic.
/// 400 TOPIC_CLOSE_SEPARATELY The <code>close</code> flag cannot be provided together with any of the other flags.
/// 400 TOPIC_HIDE_SEPARATELY The <code>hide</code> flag cannot be provided together with any of the other flags.
/// 400 TOPIC_ID_INVALID The specified topic ID is invalid.
/// 400 TOPIC_NOT_MODIFIED The updated topic info is equal to the current topic info, nothing was changed.
/// See <a href="https://corefork.telegram.org/method/channels.editForumTopic" />
///</summary>
[TlObject(0xf4dfa185)]
public sealed class RequestEditForumTopic : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xf4dfa185;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Supergroup
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// Topic ID
    ///</summary>
    public int TopicId { get; set; }

    ///<summary>
    /// If present, will update the topic title (maximum UTF-8 length: 128).
    ///</summary>
    public string? Title { get; set; }

    ///<summary>
    /// If present, updates the <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji</a> used as topic icon. <a href="https://corefork.telegram.org/api/premium">Telegram Premium</a> users can use any custom emoji, other users can only use the custom emojis contained in the <a href="https://corefork.telegram.org/constructor/inputStickerSetEmojiDefaultTopicIcons">inputStickerSetEmojiDefaultTopicIcons</a> emoji pack. Pass 0 to switch to the fallback topic icon.
    ///</summary>
    public long? IconEmojiId { get; set; }

    ///<summary>
    /// If present, will update the open/closed status of the topic.
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool? Closed { get; set; }

    ///<summary>
    /// If present, will hide/unhide the topic (only valid for the "General" topic, <code>id=1</code>).
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool? Hidden { get; set; }

    public void ComputeFlag()
    {
        if (Title != null) { Flags[0] = true; }
        if (/*IconEmojiId != 0 &&*/ IconEmojiId.HasValue) { Flags[1] = true; }
        if (Closed !=null) { Flags[2] = true; }
        if (Hidden !=null) { Flags[3] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Channel);
        writer.Write(TopicId);
        if (Flags[0]) { writer.Write(Title); }
        if (Flags[1]) { writer.Write(IconEmojiId.Value); }
        if (Flags[2]) { writer.Write(Closed.Value); }
        if (Flags[3]) { writer.Write(Hidden.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        TopicId = reader.ReadInt32();
        if (Flags[0]) { Title = reader.ReadString(); }
        if (Flags[1]) { IconEmojiId = reader.ReadInt64(); }
        if (Flags[2]) { Closed = reader.Read(); }
        if (Flags[3]) { Hidden = reader.Read(); }
    }
}
