﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
///See <a href="https://core.telegram.org/method/auth.signUp" />
///</summary>
[TlObject(0x80eee427)]
public sealed class RequestSignUp : IRequest<MyTelegram.Schema.Auth.IAuthorization>
{
    public uint ConstructorId => 0x80eee427;
    public string PhoneNumber { get; set; }
    public string PhoneCodeHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(PhoneNumber);
        bw.Serialize(PhoneCodeHash);
        bw.Serialize(FirstName);
        bw.Serialize(LastName);
    }

    public void Deserialize(BinaryReader br)
    {
        PhoneNumber = br.Deserialize<string>();
        PhoneCodeHash = br.Deserialize<string>();
        FirstName = br.Deserialize<string>();
        LastName = br.Deserialize<string>();
    }
}