﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Used to gift <a href="https://corefork.telegram.org/api/stars">Telegram Stars</a> to a friend.
/// See <a href="https://corefork.telegram.org/constructor/inputStorePaymentStarsGift" />
///</summary>
[TlObject(0x1d741ef7)]
public sealed class TInputStorePaymentStarsGift : IInputStorePaymentPurpose
{
    public uint ConstructorId => 0x1d741ef7;
    ///<summary>
    /// The user to which the stars should be gifted.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser UserId { get; set; }

    ///<summary>
    /// Amount of stars to gift
    ///</summary>
    public long Stars { get; set; }

    ///<summary>
    /// Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    public long Amount { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(UserId);
        writer.Write(Stars);
        writer.Write(Currency);
        writer.Write(Amount);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        Stars = reader.ReadInt64();
        Currency = reader.ReadString();
        Amount = reader.ReadInt64();
    }
}