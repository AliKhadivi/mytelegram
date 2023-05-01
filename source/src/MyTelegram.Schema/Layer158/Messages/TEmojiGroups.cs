﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;


///<summary>
///See <a href="https://core.telegram.org/constructor/messages.emojiGroups" />
///</summary>
[TlObject(0x881fb94b)]
public sealed class TEmojiGroups : IEmojiGroups
{
    public uint ConstructorId => 0x881fb94b;
    public int Hash { get; set; }
    public TVector<MyTelegram.Schema.IEmojiGroup> Groups { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Hash);
        Groups.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Hash = br.ReadInt32();
        Groups = br.Deserialize<TVector<MyTelegram.Schema.IEmojiGroup>>();
    }
}