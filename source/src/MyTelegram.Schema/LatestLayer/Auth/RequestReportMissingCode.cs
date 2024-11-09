﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
/// Official apps only, reports that the SMS authentication code wasn't delivered.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PHONE_NUMBER_INVALID The phone number is invalid.
/// See <a href="https://corefork.telegram.org/method/auth.reportMissingCode" />
///</summary>
[TlObject(0xcb9deff6)]
public sealed class RequestReportMissingCode : IRequest<IBool>
{
    public uint ConstructorId => 0xcb9deff6;
    ///<summary>
    /// Phone number where we were supposed to receive the code
    ///</summary>
    public string PhoneNumber { get; set; }

    ///<summary>
    /// The phone code hash obtained from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a>
    ///</summary>
    public string PhoneCodeHash { get; set; }

    ///<summary>
    /// <a href="https://en.wikipedia.org/wiki/Mobile_country_code">MNC</a> of the current network operator.
    ///</summary>
    public string Mnc { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PhoneNumber);
        writer.Write(PhoneCodeHash);
        writer.Write(Mnc);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PhoneNumber = reader.ReadString();
        PhoneCodeHash = reader.ReadString();
        Mnc = reader.ReadString();
    }
}
