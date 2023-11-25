﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// Credit card info, provided by the card's bank(s)
/// See <a href="https://corefork.telegram.org/constructor/payments.bankCardData" />
///</summary>
[TlObject(0x3e24e573)]
public sealed class TBankCardData : IBankCardData
{
    public uint ConstructorId => 0x3e24e573;
    ///<summary>
    /// Credit card title
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// Info URL(s) provided by the card's bank(s)
    ///</summary>
    public TVector<MyTelegram.Schema.IBankCardOpenUrl> OpenUrls { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Title);
        writer.Write(OpenUrls);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Title = reader.ReadString();
        OpenUrls = reader.Read<TVector<MyTelegram.Schema.IBankCardOpenUrl>>();
    }
}