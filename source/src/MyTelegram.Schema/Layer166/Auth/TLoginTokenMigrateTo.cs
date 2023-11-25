﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
/// Repeat the query to the specified DC
/// See <a href="https://corefork.telegram.org/constructor/auth.loginTokenMigrateTo" />
///</summary>
[TlObject(0x68e9916)]
public sealed class TLoginTokenMigrateTo : ILoginToken
{
    public uint ConstructorId => 0x68e9916;
    ///<summary>
    /// DC ID
    ///</summary>
    public int DcId { get; set; }

    ///<summary>
    /// Token to use for login
    ///</summary>
    public byte[] Token { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(DcId);
        writer.Write(Token);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        DcId = reader.ReadInt32();
        Token = reader.ReadBytes();
    }
}