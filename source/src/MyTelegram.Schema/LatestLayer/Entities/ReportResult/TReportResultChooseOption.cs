﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/reportResultChooseOption" />
///</summary>
[TlObject(0xf0e4e0b6)]
public sealed class TReportResultChooseOption : IReportResult
{
    public uint ConstructorId => 0xf0e4e0b6;
    public string Title { get; set; }
    public TVector<MyTelegram.Schema.IMessageReportOption> Options { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Title);
        writer.Write(Options);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Title = reader.ReadString();
        Options = reader.Read<TVector<MyTelegram.Schema.IMessageReportOption>>();
    }
}