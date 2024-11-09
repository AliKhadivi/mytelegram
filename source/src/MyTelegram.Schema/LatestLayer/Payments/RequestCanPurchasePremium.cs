﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// Checks whether Telegram Premium purchase is possible. Must be called before in-store Premium purchase, official apps only.
/// <para>Possible errors</para>
/// Code Type Description
/// 406 PREMIUM_CURRENTLY_UNAVAILABLE You cannot currently purchase a Premium subscription.
/// See <a href="https://corefork.telegram.org/method/payments.canPurchasePremium" />
///</summary>
[TlObject(0x9fc19eb6)]
public sealed class RequestCanPurchasePremium : IRequest<IBool>
{
    public uint ConstructorId => 0x9fc19eb6;
    ///<summary>
    /// Payment purpose
    /// See <a href="https://corefork.telegram.org/type/InputStorePaymentPurpose" />
    ///</summary>
    public MyTelegram.Schema.IInputStorePaymentPurpose Purpose { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Purpose);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Purpose = reader.Read<MyTelegram.Schema.IInputStorePaymentPurpose>();
    }
}
