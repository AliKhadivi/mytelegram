﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.getLeftChannels" />
///</summary>
[TlObject(0x8341ecc0)]
public sealed class RequestGetLeftChannels : IRequest<MyTelegram.Schema.Messages.IChats>
{
    public uint ConstructorId => 0x8341ecc0;
    public int Offset { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Offset);
    }

    public void Deserialize(BinaryReader br)
    {
        Offset = br.ReadInt32();
    }
}