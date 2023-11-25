﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Report a profile photo of a dialog
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/account.reportProfilePhoto" />
///</summary>
[TlObject(0xfa8cc6f5)]
public sealed class RequestReportProfilePhoto : IRequest<IBool>
{
    public uint ConstructorId => 0xfa8cc6f5;
    ///<summary>
    /// The dialog
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// Dialog photo ID
    /// See <a href="https://corefork.telegram.org/type/InputPhoto" />
    ///</summary>
    public MyTelegram.Schema.IInputPhoto PhotoId { get; set; }

    ///<summary>
    /// Report reason
    /// See <a href="https://corefork.telegram.org/type/ReportReason" />
    ///</summary>
    public MyTelegram.Schema.IReportReason Reason { get; set; }

    ///<summary>
    /// Comment for report moderation
    ///</summary>
    public string Message { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(PhotoId);
        writer.Write(Reason);
        writer.Write(Message);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        PhotoId = reader.Read<MyTelegram.Schema.IInputPhoto>();
        Reason = reader.Read<MyTelegram.Schema.IReportReason>();
        Message = reader.ReadString();
    }
}