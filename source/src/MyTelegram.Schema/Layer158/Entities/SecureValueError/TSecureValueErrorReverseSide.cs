﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/secureValueErrorReverseSide" />
///</summary>
[TlObject(0x868a2aa5)]
public sealed class TSecureValueErrorReverseSide : ISecureValueError
{
    public uint ConstructorId => 0x868a2aa5;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/SecureValueType" />
    ///</summary>
    public MyTelegram.Schema.ISecureValueType Type { get; set; }
    public byte[] FileHash { get; set; }
    public string Text { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Type.Serialize(bw);
        bw.Serialize(FileHash);
        bw.Serialize(Text);
    }

    public void Deserialize(BinaryReader br)
    {
        Type = br.Deserialize<MyTelegram.Schema.ISecureValueType>();
        FileHash = br.Deserialize<byte[]>();
        Text = br.Deserialize<string>();
    }
}