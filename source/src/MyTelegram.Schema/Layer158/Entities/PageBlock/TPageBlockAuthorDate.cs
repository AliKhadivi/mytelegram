﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/pageBlockAuthorDate" />
///</summary>
[TlObject(0xbaafe5e0)]
public sealed class TPageBlockAuthorDate : IPageBlock
{
    public uint ConstructorId => 0xbaafe5e0;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/RichText" />
    ///</summary>
    public MyTelegram.Schema.IRichText Author { get; set; }
    public int PublishedDate { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Author.Serialize(bw);
        bw.Write(PublishedDate);
    }

    public void Deserialize(BinaryReader br)
    {
        Author = br.Deserialize<MyTelegram.Schema.IRichText>();
        PublishedDate = br.ReadInt32();
    }
}