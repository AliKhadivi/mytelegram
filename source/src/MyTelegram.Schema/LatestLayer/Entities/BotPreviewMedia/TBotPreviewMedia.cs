﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">Main Mini App preview media, see here »</a> for more info.
/// See <a href="https://corefork.telegram.org/constructor/botPreviewMedia" />
///</summary>
[TlObject(0x23e91ba3)]
public sealed class TBotPreviewMedia : IBotPreviewMedia
{
    public uint ConstructorId => 0x23e91ba3;
    ///<summary>
    /// When was this media last updated.
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// The actual photo/video.
    /// See <a href="https://corefork.telegram.org/type/MessageMedia" />
    ///</summary>
    public MyTelegram.Schema.IMessageMedia Media { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Date);
        writer.Write(Media);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Date = reader.ReadInt32();
        Media = reader.Read<MyTelegram.Schema.IMessageMedia>();
    }
}