﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/stickerSetFullCovered" />
///</summary>
[TlObject(0x1aed5ee5)]
public class TStickerSetFullCovered : IStickerSetCovered
{
    public uint ConstructorId => 0x1aed5ee5;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/StickerSet" />
    ///</summary>
    public MyTelegram.Schema.IStickerSet Set { get; set; }
    public TVector<MyTelegram.Schema.IStickerPack> Packs { get; set; }
    public TVector<MyTelegram.Schema.IDocument> Documents { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Set.Serialize(bw);
        Packs.Serialize(bw);
        Documents.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Set = br.Deserialize<MyTelegram.Schema.IStickerSet>();
        Packs = br.Deserialize<TVector<MyTelegram.Schema.IStickerPack>>();
        Documents = br.Deserialize<TVector<MyTelegram.Schema.IDocument>>();
    }
}