﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a channel post
/// See <a href="https://corefork.telegram.org/constructor/inputMediaAreaChannelPost" />
///</summary>
[TlObject(0x2271f2bf)]
public sealed class TInputMediaAreaChannelPost : IMediaArea
{
    public uint ConstructorId => 0x2271f2bf;
    ///<summary>
    /// The size and location of the media area corresponding to the location sticker on top of the story media.
    /// See <a href="https://corefork.telegram.org/type/MediaAreaCoordinates" />
    ///</summary>
    public MyTelegram.Schema.IMediaAreaCoordinates Coordinates { get; set; }

    ///<summary>
    /// The channel that posted the message
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// ID of the channel message
    ///</summary>
    public int MsgId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Coordinates);
        writer.Write(Channel);
        writer.Write(MsgId);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Coordinates = reader.Read<MyTelegram.Schema.IMediaAreaCoordinates>();
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        MsgId = reader.ReadInt32();
    }
}