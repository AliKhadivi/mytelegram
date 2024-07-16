﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/messageMediaPaidMedia" />
///</summary>
[TlObject(0xa8852491)]
public sealed class TMessageMediaPaidMedia : IMessageMedia
{
    public uint ConstructorId => 0xa8852491;
    public long StarsAmount { get; set; }
    public TVector<MyTelegram.Schema.IMessageExtendedMedia> ExtendedMedia { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(StarsAmount);
        writer.Write(ExtendedMedia);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        StarsAmount = reader.ReadInt64();
        ExtendedMedia = reader.Read<TVector<MyTelegram.Schema.IMessageExtendedMedia>>();
    }
}