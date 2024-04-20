﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Associate a stickerset to the supergroup
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHAT_ID_INVALID The provided chat id is invalid.
/// 400 PARTICIPANTS_TOO_FEW Not enough participants.
/// 406 STICKERSET_OWNER_ANONYMOUS Provided stickerset can't be installed as group stickerset to prevent admin deanonymization.
/// See <a href="https://corefork.telegram.org/method/channels.setStickers" />
///</summary>
[TlObject(0xea8ca4f9)]
public sealed class RequestSetStickers : IRequest<IBool>
{
    public uint ConstructorId => 0xea8ca4f9;
    ///<summary>
    /// Supergroup
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// The stickerset to associate
    /// See <a href="https://corefork.telegram.org/type/InputStickerSet" />
    ///</summary>
    public MyTelegram.Schema.IInputStickerSet Stickerset { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
        writer.Write(Stickerset);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        Stickerset = reader.Read<MyTelegram.Schema.IInputStickerSet>();
    }
}
