﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;


///<summary>
///See <a href="https://core.telegram.org/constructor/messages.checkedHistoryImportPeer" />
///</summary>
[TlObject(0xa24de717)]
public sealed class TCheckedHistoryImportPeer : ICheckedHistoryImportPeer
{
    public uint ConstructorId => 0xa24de717;
    public string ConfirmText { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(ConfirmText);
    }

    public void Deserialize(BinaryReader br)
    {
        ConfirmText = br.Deserialize<string>();
    }
}