﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Deletes a device by its token, stops sending PUSH-notifications to it.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 TOKEN_INVALID The provided token is invalid.
/// See <a href="https://corefork.telegram.org/method/account.unregisterDevice" />
///</summary>
[TlObject(0x6a0d3206)]
public sealed class RequestUnregisterDevice : IRequest<IBool>
{
    public uint ConstructorId => 0x6a0d3206;
    ///<summary>
    /// Device token type, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.
    ///</summary>
    public int TokenType { get; set; }

    ///<summary>
    /// Device token, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.
    ///</summary>
    public string Token { get; set; }

    ///<summary>
    /// List of user identifiers of other users currently using the client
    ///</summary>
    public TVector<long> OtherUids { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(TokenType);
        writer.Write(Token);
        writer.Write(OtherUids);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        TokenType = reader.ReadInt32();
        Token = reader.ReadString();
        OtherUids = reader.Read<TVector<long>>();
    }
}