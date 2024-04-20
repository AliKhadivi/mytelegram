﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
/// Fetch new chats associated with an imported <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>. Must be invoked at most every <code>chatlist_update_period</code> seconds (as per the related <a href="https://corefork.telegram.org/api/config#chatlist-update-period">client configuration parameter »</a>).
/// <para>Possible errors</para>
/// Code Type Description
/// 400 FILTER_ID_INVALID The specified filter ID is invalid.
/// 400 FILTER_NOT_SUPPORTED The specified filter cannot be used in this context.
/// 400 INPUT_CHATLIST_INVALID The specified folder is invalid.
/// See <a href="https://corefork.telegram.org/method/chatlists.getChatlistUpdates" />
///</summary>
[TlObject(0x89419521)]
public sealed class RequestGetChatlistUpdates : IRequest<MyTelegram.Schema.Chatlists.IChatlistUpdates>
{
    public uint ConstructorId => 0x89419521;
    ///<summary>
    /// The folder
    /// See <a href="https://corefork.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Chatlist);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Chatlist = reader.Read<MyTelegram.Schema.IInputChatlist>();
    }
}
