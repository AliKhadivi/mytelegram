﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth.LayerN;

///<summary>
/// Registers a validated phone number in the system.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 FIRSTNAME_INVALID The first name is invalid.
/// 400 LASTNAME_INVALID The last name is invalid.
/// 400 PHONE_CODE_EMPTY phone_code is missing.
/// 400 PHONE_CODE_EXPIRED The phone code you provided has expired.
/// 400 PHONE_CODE_INVALID The provided phone code is invalid.
/// 400 PHONE_NUMBER_FLOOD You asked for the code too many times.
/// 406 PHONE_NUMBER_INVALID The phone number is invalid.
/// 400 PHONE_NUMBER_OCCUPIED The phone number is already in use.
/// See <a href="https://corefork.telegram.org/method/auth.signUp" />
///</summary>
[TlObject(0x80eee427)]
public sealed class RequestSignUp : IRequest<MyTelegram.Schema.Auth.IAuthorization>
{
    public uint ConstructorId => 0x80eee427;
    ///<summary>
    /// Phone number in the international format
    ///</summary>
    public string PhoneNumber { get; set; }

    ///<summary>
    /// SMS-message ID
    ///</summary>
    public string PhoneCodeHash { get; set; }

    ///<summary>
    /// New user first name
    ///</summary>
    public string FirstName { get; set; }

    ///<summary>
    /// New user last name
    ///</summary>
    public string LastName { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PhoneNumber);
        writer.Write(PhoneCodeHash);
        writer.Write(FirstName);
        writer.Write(LastName);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PhoneNumber = reader.ReadString();
        PhoneCodeHash = reader.ReadString();
        FirstName = reader.ReadString();
        LastName = reader.ReadString();
    }
}