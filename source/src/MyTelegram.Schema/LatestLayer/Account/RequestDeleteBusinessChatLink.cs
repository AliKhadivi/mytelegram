﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Delete a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link »</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHATLINK_SLUG_EMPTY The specified slug is empty.
/// 400 CHATLINK_SLUG_EXPIRED The specified <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat link</a> has expired.
/// See <a href="https://corefork.telegram.org/method/account.deleteBusinessChatLink" />
///</summary>
[TlObject(0x60073674)]
public sealed class RequestDeleteBusinessChatLink : IRequest<IBool>
{
    public uint ConstructorId => 0x60073674;
    ///<summary>
    /// Slug of the link, obtained as specified <a href="https://corefork.telegram.org/api/links#business-chat-links">here »</a>.
    ///</summary>
    public string Slug { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Slug);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Slug = reader.ReadString();
    }
}
