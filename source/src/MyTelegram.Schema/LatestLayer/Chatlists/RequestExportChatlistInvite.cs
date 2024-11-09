﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
/// Export a <a href="https://corefork.telegram.org/api/folders">folder »</a>, creating a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 FILTER_ID_INVALID The specified filter ID is invalid.
/// 400 FILTER_NOT_SUPPORTED The specified filter cannot be used in this context.
/// 400 INVITES_TOO_MUCH The maximum number of per-folder invites specified by the <code>chatlist_invites_limit_default</code>/<code>chatlist_invites_limit_premium</code> <a href="https://corefork.telegram.org/api/config#chatlist-invites-limit-default">client configuration parameters&nbsp;»</a> was reached.
/// 400 PEERS_LIST_EMPTY The specified list of peers is empty.
/// See <a href="https://corefork.telegram.org/method/chatlists.exportChatlistInvite" />
///</summary>
[TlObject(0x8472478e)]
public sealed class RequestExportChatlistInvite : IRequest<MyTelegram.Schema.Chatlists.IExportedChatlistInvite>
{
    public uint ConstructorId => 0x8472478e;
    ///<summary>
    /// The folder to export
    /// See <a href="https://corefork.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }

    ///<summary>
    /// An optional name for the link
    ///</summary>
    public string Title { get; set; }

    ///<summary>
    /// The list of channels, group and supergroups to share with the link. Basic groups will automatically be <a href="https://corefork.telegram.org/api/channel#migration">converted to supergroups</a> when invoking the method.
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
        writer.Write(Title);
        writer.Write(Peers);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Chatlist = reader.Read<MyTelegram.Schema.IInputChatlist>();
        Title = reader.ReadString();
        Peers = reader.Read<TVector<MyTelegram.Schema.IInputPeer>>();
    }
}
