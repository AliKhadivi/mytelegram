﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Peer in a folder
/// See <a href="https://corefork.telegram.org/constructor/folderPeer" />
///</summary>
[TlObject(0xe9baa668)]
public sealed class TFolderPeer : IFolderPeer
{
    public uint ConstructorId => 0xe9baa668;
    ///<summary>
    /// Folder peer info
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a>
    ///</summary>
    public int FolderId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(FolderId);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        FolderId = reader.ReadInt32();
    }
}