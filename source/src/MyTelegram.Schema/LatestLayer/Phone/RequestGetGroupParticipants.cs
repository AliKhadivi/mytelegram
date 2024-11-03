﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Phone;

///<summary>
/// Get group call participants
/// <para>Possible errors</para>
/// Code Type Description
/// 400 GROUPCALL_INVALID The specified group call is invalid.
/// See <a href="https://corefork.telegram.org/method/phone.getGroupParticipants" />
///</summary>
[TlObject(0xc558d8ab)]
public sealed class RequestGetGroupParticipants : IRequest<MyTelegram.Schema.Phone.IGroupParticipants>
{
    public uint ConstructorId => 0xc558d8ab;
    ///<summary>
    /// Group call
    /// See <a href="https://corefork.telegram.org/type/InputGroupCall" />
    ///</summary>
    public MyTelegram.Schema.IInputGroupCall Call { get; set; }

    ///<summary>
    /// If specified, will fetch group participant info about the specified peers
    ///</summary>
    public TVector<MyTelegram.Schema.IInputPeer> Ids { get; set; }

    ///<summary>
    /// If specified, will fetch group participant info about the specified WebRTC source IDs
    ///</summary>
    public TVector<int> Sources { get; set; }

    ///<summary>
    /// Offset for results, taken from the <code>next_offset</code> field of <a href="https://corefork.telegram.org/constructor/phone.groupParticipants">phone.groupParticipants</a>, initially an empty string. <br>Note: if no more results are available, the method call will return an empty <code>next_offset</code>; thus, avoid providing the <code>next_offset</code> returned in <a href="https://corefork.telegram.org/constructor/phone.groupParticipants">phone.groupParticipants</a> if it is empty, to avoid an infinite loop.
    ///</summary>
    public string Offset { get; set; }

    ///<summary>
    /// Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Call);
        writer.Write(Ids);
        writer.Write(Sources);
        writer.Write(Offset);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Call = reader.Read<MyTelegram.Schema.IInputGroupCall>();
        Ids = reader.Read<TVector<MyTelegram.Schema.IInputPeer>>();
        Sources = reader.Read<TVector<int>>();
        Offset = reader.ReadString();
        Limit = reader.ReadInt32();
    }
}
