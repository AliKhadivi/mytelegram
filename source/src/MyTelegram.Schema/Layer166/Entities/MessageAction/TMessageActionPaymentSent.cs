﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A payment was sent
/// See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSent" />
///</summary>
[TlObject(0x96163f56)]
public sealed class TMessageActionPaymentSent : IMessageAction
{
    public uint ConstructorId => 0x96163f56;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether this is the first payment of a recurring payment we just subscribed to
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool RecurringInit { get; set; }

    ///<summary>
    /// Whether this payment is part of a recurring payment
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool RecurringUsed { get; set; }

    ///<summary>
    /// Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    public long TotalAmount { get; set; }

    ///<summary>
    /// An invoice slug taken from an <a href="https://corefork.telegram.org/api/links#invoice-links">invoice deep link</a> or from the <a href="https://corefork.telegram.org/api/config#premium-invoice-slug"><code>premium_invoice_slug</code> app config parameter »</a>
    ///</summary>
    public string? InvoiceSlug { get; set; }

    public void ComputeFlag()
    {
        if (RecurringInit) { Flags[2] = true; }
        if (RecurringUsed) { Flags[3] = true; }
        if (InvoiceSlug != null) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Currency);
        writer.Write(TotalAmount);
        if (Flags[0]) { writer.Write(InvoiceSlug); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[2]) { RecurringInit = true; }
        if (Flags[3]) { RecurringUsed = true; }
        Currency = reader.ReadString();
        TotalAmount = reader.ReadInt64();
        if (Flags[0]) { InvoiceSlug = reader.ReadString(); }
    }
}