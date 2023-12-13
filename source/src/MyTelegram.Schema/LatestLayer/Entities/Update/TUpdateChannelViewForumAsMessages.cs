﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/updateChannelViewForumAsMessages" />
///</summary>
[TlObject(0x7b68920)]
public sealed class TUpdateChannelViewForumAsMessages : IUpdate
{
    public uint ConstructorId => 0x7b68920;
    ///<summary>
    /// &nbsp;
    ///</summary>
    public long ChannelId { get; set; }

    ///<summary>
    /// &nbsp;
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool Enabled { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(ChannelId);
        writer.Write(Enabled);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        ChannelId = reader.ReadInt64();
        Enabled = reader.Read();
    }
}