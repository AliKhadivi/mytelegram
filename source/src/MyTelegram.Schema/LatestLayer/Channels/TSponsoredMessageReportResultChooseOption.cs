﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// The user must choose a report option from the localized options available in <code>options</code>, and after selection, <a href="https://corefork.telegram.org/method/channels.reportSponsoredMessage">channels.reportSponsoredMessage</a> must be invoked again, passing the option's <code>option</code> field to the <code>option</code> param of the method.
/// See <a href="https://corefork.telegram.org/constructor/channels.sponsoredMessageReportResultChooseOption" />
///</summary>
[TlObject(0x846f9e42)]
public sealed class TSponsoredMessageReportResultChooseOption : ISponsoredMessageReportResult
{
    public uint ConstructorId => 0x846f9e42;
    ///<summary>
    /// Title of the option selection popup.
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// Localized list of options.
    ///</summary>
    public TVector<MyTelegram.Schema.ISponsoredMessageReportOption> Options { get; set; }

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
        Options = reader.Read<TVector<MyTelegram.Schema.ISponsoredMessageReportOption>>();
    }
}