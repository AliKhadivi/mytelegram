﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;


///<summary>
///See <a href="https://core.telegram.org/constructor/messages.allStickersNotModified" />
///</summary>
[TlObject(0xe86602c3)]
public sealed class TAllStickersNotModified : IAllStickers
{
    public uint ConstructorId => 0xe86602c3;


    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);

    }

    public void Deserialize(BinaryReader br)
    {

    }
}