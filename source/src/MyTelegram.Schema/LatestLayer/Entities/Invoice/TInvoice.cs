﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Invoice
/// See <a href="https://corefork.telegram.org/constructor/invoice" />
///</summary>
[TlObject(0x5db95a15)]
public sealed class TInvoice : IInvoice
{
    public uint ConstructorId => 0x5db95a15;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Test invoice
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Test { get; set; }

    ///<summary>
    /// Set this flag if you require the user's full name to complete the order
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool NameRequested { get; set; }

    ///<summary>
    /// Set this flag if you require the user's phone number to complete the order
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool PhoneRequested { get; set; }

    ///<summary>
    /// Set this flag if you require the user's email address to complete the order
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool EmailRequested { get; set; }

    ///<summary>
    /// Set this flag if you require the user's shipping address to complete the order
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ShippingAddressRequested { get; set; }

    ///<summary>
    /// Set this flag if the final price depends on the shipping method
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Flexible { get; set; }

    ///<summary>
    /// Set this flag if user's phone number should be sent to provider
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool PhoneToProvider { get; set; }

    ///<summary>
    /// Set this flag if user's email address should be sent to provider
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool EmailToProvider { get; set; }

    ///<summary>
    /// Whether this is a recurring payment
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Recurring { get; set; }

    ///<summary>
    /// Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code, or <code>XTR</code> for <a href="https://corefork.telegram.org/api/stars">Telegram Stars</a>.
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)
    ///</summary>
    public TVector<MyTelegram.Schema.ILabeledPrice> Prices { get; set; }

    ///<summary>
    /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    public long? MaxTipAmount { get; set; }

    ///<summary>
    /// A vector of suggested amounts of tips in the <em>smallest units</em> of the currency (integer, not float/double). At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <code>max_tip_amount</code>.
    ///</summary>
    public TVector<long>? SuggestedTipAmounts { get; set; }

    ///<summary>
    /// Terms of service URL
    ///</summary>
    public string? TermsUrl { get; set; }

    public void ComputeFlag()
    {
        if (Test) { Flags[0] = true; }
        if (NameRequested) { Flags[1] = true; }
        if (PhoneRequested) { Flags[2] = true; }
        if (EmailRequested) { Flags[3] = true; }
        if (ShippingAddressRequested) { Flags[4] = true; }
        if (Flexible) { Flags[5] = true; }
        if (PhoneToProvider) { Flags[6] = true; }
        if (EmailToProvider) { Flags[7] = true; }
        if (Recurring) { Flags[9] = true; }
        if (/*MaxTipAmount != 0 &&*/ MaxTipAmount.HasValue) { Flags[8] = true; }
        if (SuggestedTipAmounts?.Count > 0) { Flags[8] = true; }
        if (TermsUrl != null) { Flags[10] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Currency);
        writer.Write(Prices);
        if (Flags[8]) { writer.Write(MaxTipAmount.Value); }
        if (Flags[8]) { writer.Write(SuggestedTipAmounts); }
        if (Flags[10]) { writer.Write(TermsUrl); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Test = true; }
        if (Flags[1]) { NameRequested = true; }
        if (Flags[2]) { PhoneRequested = true; }
        if (Flags[3]) { EmailRequested = true; }
        if (Flags[4]) { ShippingAddressRequested = true; }
        if (Flags[5]) { Flexible = true; }
        if (Flags[6]) { PhoneToProvider = true; }
        if (Flags[7]) { EmailToProvider = true; }
        if (Flags[9]) { Recurring = true; }
        Currency = reader.ReadString();
        Prices = reader.Read<TVector<MyTelegram.Schema.ILabeledPrice>>();
        if (Flags[8]) { MaxTipAmount = reader.ReadInt64(); }
        if (Flags[8]) { SuggestedTipAmounts = reader.Read<TVector<long>>(); }
        if (Flags[10]) { TermsUrl = reader.ReadString(); }
    }
}