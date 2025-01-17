﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth.LayerN;

///<summary>
/// Contains info about a sent verification code.
/// See <a href="https://corefork.telegram.org/constructor/auth.sentCode" />
///</summary>
[TlObject(0x5e002502)]
public sealed class TSentCode : ISentCode
{
    public uint ConstructorId => 0x5e002502;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool PhoneRegistered { get; set; }

    ///<summary>
    /// Phone code type
    /// See <a href="https://corefork.telegram.org/type/auth.SentCodeType" />
    ///</summary>
    public MyTelegram.Schema.Auth.ISentCodeType Type { get; set; }

    ///<summary>
    /// Phone code hash, to be stored and later re-used with <a href="https://corefork.telegram.org/method/auth.signIn">auth.signIn</a>
    ///</summary>
    public string PhoneCodeHash { get; set; }

    ///<summary>
    /// Phone code type that will be sent next, if the phone code is not received within <code>timeout</code> seconds: to send it use <a href="https://corefork.telegram.org/method/auth.resendCode">auth.resendCode</a>
    /// See <a href="https://corefork.telegram.org/type/auth.CodeType" />
    ///</summary>
    public MyTelegram.Schema.Auth.ICodeType? NextType { get; set; }

    ///<summary>
    /// Timeout for reception of the phone code
    ///</summary>
    public int? Timeout { get; set; }

    public void ComputeFlag()
    {
        if (PhoneRegistered) { Flags[0] = true; }
        if (NextType != null) { Flags[1] = true; }
        if (/*Timeout != 0 && */Timeout.HasValue) { Flags[2] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Type);
        writer.Write(PhoneCodeHash);
        if (Flags[1]) { writer.Write(NextType); }
        if (Flags[2]) { writer.Write(Timeout.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { PhoneRegistered = true; }
        Type = reader.Read<MyTelegram.Schema.Auth.ISentCodeType>();
        PhoneCodeHash = reader.ReadString();
        if (Flags[1]) { NextType = reader.Read<MyTelegram.Schema.Auth.ICodeType>(); }
        if (Flags[2]) { Timeout = reader.ReadInt32(); }
    }
}