﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Upload;

///<summary>
/// Returns content of a whole file or its part.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CDN_METHOD_INVALID You can't call this method in a CDN DC.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 406 FILEREF_UPGRADE_NEEDED The client has to be updated in order to support <a href="https://corefork.telegram.org/api/file_reference">file references</a>.
/// 400 FILE_ID_INVALID The provided file id is invalid.
/// 400 FILE_REFERENCE_EXPIRED File reference expired, it must be refetched as described in <a href="https://corefork.telegram.org/api/file_reference">the documentation</a>.
/// 420 FLOOD_PREMIUM_WAIT_%d Please wait %d seconds before repeating the action, or purchase a <a href="https://corefork.telegram.org/api/premium">Telegram Premium subscription</a> to remove this rate limit.
/// 400 LIMIT_INVALID The provided limit is invalid.
/// 400 LOCATION_INVALID The provided location is invalid.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 OFFSET_INVALID The provided offset is invalid.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/upload.getFile" />
///</summary>
[TlObject(0xbe5335be)]
public sealed class RequestGetFile : IRequest<MyTelegram.Schema.Upload.IFile>
{
    public uint ConstructorId => 0xbe5335be;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Disable some checks on limit and offset values, useful for example to stream videos by keyframes
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Precise { get; set; }

    ///<summary>
    /// Whether the current client supports <a href="https://corefork.telegram.org/cdn">CDN downloads</a>
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CdnSupported { get; set; }

    ///<summary>
    /// File location
    /// See <a href="https://corefork.telegram.org/type/InputFileLocation" />
    ///</summary>
    public MyTelegram.Schema.IInputFileLocation Location { get; set; }

    ///<summary>
    /// Number of bytes to be skipped
    ///</summary>
    public long Offset { get; set; }

    ///<summary>
    /// Number of bytes to be returned
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {
        if (Precise) { Flags[0] = true; }
        if (CdnSupported) { Flags[1] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Location);
        writer.Write(Offset);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Precise = true; }
        if (Flags[1]) { CdnSupported = true; }
        Location = reader.Read<MyTelegram.Schema.IInputFileLocation>();
        Offset = reader.ReadInt64();
        Limit = reader.ReadInt32();
    }
}
