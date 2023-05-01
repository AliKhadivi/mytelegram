﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updateChatParticipantDelete" />
///</summary>
[TlObject(0xe32f3d77)]
public sealed class TUpdateChatParticipantDelete : IUpdate
{
    public uint ConstructorId => 0xe32f3d77;
    public long ChatId { get; set; }
    public long UserId { get; set; }
    public int Version { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(ChatId);
        bw.Write(UserId);
        bw.Write(Version);
    }

    public void Deserialize(BinaryReader br)
    {
        ChatId = br.ReadInt64();
        UserId = br.ReadInt64();
        Version = br.ReadInt32();
    }
}