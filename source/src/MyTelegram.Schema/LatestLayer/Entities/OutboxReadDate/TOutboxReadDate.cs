﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Exact read date of a private message we sent to another user.
/// See <a href="https://corefork.telegram.org/constructor/outboxReadDate" />
///</summary>
[TlObject(0x3bb842ac)]
public sealed class TOutboxReadDate : IOutboxReadDate
{
    public uint ConstructorId => 0x3bb842ac;
    ///<summary>
    /// UNIX timestamp with the read date.
    ///</summary>
    public int Date { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Date);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Date = reader.ReadInt32();
    }
}