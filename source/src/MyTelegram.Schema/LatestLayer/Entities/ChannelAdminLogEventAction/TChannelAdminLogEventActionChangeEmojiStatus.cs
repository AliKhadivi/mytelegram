﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeEmojiStatus" />
///</summary>
[TlObject(0x3ea9feb1)]
public sealed class TChannelAdminLogEventActionChangeEmojiStatus : IChannelAdminLogEventAction
{
    public uint ConstructorId => 0x3ea9feb1;
    public MyTelegram.Schema.IEmojiStatus PrevValue { get; set; }
    public MyTelegram.Schema.IEmojiStatus NewValue { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PrevValue);
        writer.Write(NewValue);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PrevValue = reader.Read<MyTelegram.Schema.IEmojiStatus>();
        NewValue = reader.Read<MyTelegram.Schema.IEmojiStatus>();
    }
}