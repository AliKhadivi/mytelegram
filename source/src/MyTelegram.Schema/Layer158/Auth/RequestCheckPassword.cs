﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
///See <a href="https://core.telegram.org/method/auth.checkPassword" />
///</summary>
[TlObject(0xd18b4d16)]
public sealed class RequestCheckPassword : IRequest<MyTelegram.Schema.Auth.IAuthorization>
{
    public uint ConstructorId => 0xd18b4d16;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputCheckPasswordSRP" />
    ///</summary>
    public MyTelegram.Schema.IInputCheckPasswordSRP Password { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Password.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Password = br.Deserialize<MyTelegram.Schema.IInputCheckPasswordSRP>();
    }
}