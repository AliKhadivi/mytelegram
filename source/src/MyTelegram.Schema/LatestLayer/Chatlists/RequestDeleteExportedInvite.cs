﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
/// Delete a previously created <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 FILTER_ID_INVALID The specified filter ID is invalid.
/// 400 FILTER_NOT_SUPPORTED The specified filter cannot be used in this context.
/// See <a href="https://corefork.telegram.org/method/chatlists.deleteExportedInvite" />
///</summary>
[TlObject(0x719c5c5e)]
public sealed class RequestDeleteExportedInvite : IRequest<IBool>
{
    public uint ConstructorId => 0x719c5c5e;
    ///<summary>
    /// The related folder
    /// See <a href="https://corefork.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }

    ///<summary>
    /// <code>slug</code> obtained from the <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.
    ///</summary>
    public string Slug { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Chatlist);
        writer.Write(Slug);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Chatlist = reader.Read<MyTelegram.Schema.IInputChatlist>();
        Slug = reader.ReadString();
    }
}
