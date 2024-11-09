﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
/// Delete a folder imported using a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 FILTER_ID_INVALID The specified filter ID is invalid.
/// See <a href="https://corefork.telegram.org/method/chatlists.leaveChatlist" />
///</summary>
[TlObject(0x74fae13a)]
public sealed class RequestLeaveChatlist : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x74fae13a;
    ///<summary>
    /// Folder ID
    /// See <a href="https://corefork.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }

    ///<summary>
    /// Also leave the specified channels and groups
    ///</summary>
    public TVector<MyTelegram.Schema.IInputPeer> Peers { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Chatlist);
        writer.Write(Peers);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Chatlist = reader.Read<MyTelegram.Schema.IInputChatlist>();
        Peers = reader.Read<TVector<MyTelegram.Schema.IInputPeer>>();
    }
}
