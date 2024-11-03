﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Phone;

///<summary>
/// Save phone call debug information
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CALL_PEER_INVALID The provided call peer object is invalid.
/// See <a href="https://corefork.telegram.org/method/phone.saveCallLog" />
///</summary>
[TlObject(0x41248786)]
public sealed class RequestSaveCallLog : IRequest<IBool>
{
    public uint ConstructorId => 0x41248786;
    ///<summary>
    /// Phone call
    /// See <a href="https://corefork.telegram.org/type/InputPhoneCall" />
    ///</summary>
    public MyTelegram.Schema.IInputPhoneCall Peer { get; set; }

    ///<summary>
    /// Logs
    /// See <a href="https://corefork.telegram.org/type/InputFile" />
    ///</summary>
    public MyTelegram.Schema.IInputFile File { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(File);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPhoneCall>();
        File = reader.Read<MyTelegram.Schema.IInputFile>();
    }
}
