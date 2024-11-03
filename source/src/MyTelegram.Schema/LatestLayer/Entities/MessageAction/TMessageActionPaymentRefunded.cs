﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Describes a payment refund (service message received by both users and bots).
/// See <a href="https://corefork.telegram.org/constructor/messageActionPaymentRefunded" />
///</summary>
[TlObject(0x41b3e202)]
public sealed class TMessageActionPaymentRefunded : IMessageAction
{
    public uint ConstructorId => 0x41b3e202;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Identifier of the peer that returned the funds.
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }

    ///<summary>
    /// Currency, <code>XTR</code> for Telegram Stars.
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    public long TotalAmount { get; set; }

    ///<summary>
    /// Bot specified invoice payload (only received by bots).
    ///</summary>
    public byte[]? Payload { get; set; }

    ///<summary>
    /// Provider payment identifier
    /// See <a href="https://corefork.telegram.org/type/PaymentCharge" />
    ///</summary>
    public MyTelegram.Schema.IPaymentCharge Charge { get; set; }

    public void ComputeFlag()
    {
        if (Payload != null) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(Currency);
        writer.Write(TotalAmount);
        if (Flags[0]) { writer.Write(Payload); }
        writer.Write(Charge);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        Currency = reader.ReadString();
        TotalAmount = reader.ReadInt64();
        if (Flags[0]) { Payload = reader.ReadBytes(); }
        Charge = reader.Read<MyTelegram.Schema.IPaymentCharge>();
    }
}