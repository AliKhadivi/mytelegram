﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Phone;

///<summary>
/// Leave a group call
/// <para>Possible errors</para>
/// Code Type Description
/// 400 GROUPCALL_INVALID The specified group call is invalid.
/// See <a href="https://corefork.telegram.org/method/phone.leaveGroupCall" />
///</summary>
[TlObject(0x500377f9)]
public sealed class RequestLeaveGroupCall : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x500377f9;
    ///<summary>
    /// The group call
    /// See <a href="https://corefork.telegram.org/type/InputGroupCall" />
    ///</summary>
    public MyTelegram.Schema.IInputGroupCall Call { get; set; }

    ///<summary>
    /// Your source ID
    ///</summary>
    public int Source { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Call);
        writer.Write(Source);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Call = reader.Read<MyTelegram.Schema.IInputGroupCall>();
        Source = reader.ReadInt32();
    }
}
