﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Invoice
/// See <a href="https://corefork.telegram.org/constructor/messageMediaInvoice" />
///</summary>
[TlObject(0xf6a548d3)]
public sealed class TMessageMediaInvoice : IMessageMedia
{
    public uint ConstructorId => 0xf6a548d3;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether the shipping address was requested
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ShippingAddressRequested { get; set; }

    ///<summary>
    /// Whether this is an example invoice
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Test { get; set; }

    ///<summary>
    /// Product name, 1-32 characters
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// Product description, 1-255 characters
    ///</summary>
    public string Description { get; set; }

    ///<summary>
    /// URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. People like it better when they see what they are paying for.
    /// See <a href="https://corefork.telegram.org/type/WebDocument" />
    ///</summary>
    public MyTelegram.Schema.IWebDocument? Photo { get; set; }

    ///<summary>
    /// Message ID of receipt: if set, clients should change the text of the first <a href="https://corefork.telegram.org/constructor/keyboardButtonBuy">keyboardButtonBuy</a> button always attached to the <a href="https://corefork.telegram.org/constructor/message">message</a> to a localized version of the word <code>Receipt</code>
    ///</summary>
    public int? ReceiptMsgId { get; set; }

    ///<summary>
    /// Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code, or <code>XTR</code> for <a href="https://corefork.telegram.org/api/stars">Telegram Stars</a>.
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    public long TotalAmount { get; set; }

    ///<summary>
    /// Unique bot deep-linking parameter that can be used to generate this invoice
    ///</summary>
    public string StartParam { get; set; }

    ///<summary>
    /// Deprecated
    /// See <a href="https://corefork.telegram.org/type/MessageExtendedMedia" />
    ///</summary>
    public MyTelegram.Schema.IMessageExtendedMedia? ExtendedMedia { get; set; }

    public void ComputeFlag()
    {
        if (ShippingAddressRequested) { Flags[1] = true; }
        if (Test) { Flags[3] = true; }
        if (Photo != null) { Flags[0] = true; }
        if (/*ReceiptMsgId != 0 && */ReceiptMsgId.HasValue) { Flags[2] = true; }
        if (ExtendedMedia != null) { Flags[4] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Title);
        writer.Write(Description);
        if (Flags[0]) { writer.Write(Photo); }
        if (Flags[2]) { writer.Write(ReceiptMsgId.Value); }
        writer.Write(Currency);
        writer.Write(TotalAmount);
        writer.Write(StartParam);
        if (Flags[4]) { writer.Write(ExtendedMedia); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[1]) { ShippingAddressRequested = true; }
        if (Flags[3]) { Test = true; }
        Title = reader.ReadString();
        Description = reader.ReadString();
        if (Flags[0]) { Photo = reader.Read<MyTelegram.Schema.IWebDocument>(); }
        if (Flags[2]) { ReceiptMsgId = reader.ReadInt32(); }
        Currency = reader.ReadString();
        TotalAmount = reader.ReadInt64();
        StartParam = reader.ReadString();
        if (Flags[4]) { ExtendedMedia = reader.Read<MyTelegram.Schema.IMessageExtendedMedia>(); }
    }
}