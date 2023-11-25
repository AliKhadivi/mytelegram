﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Requested phone call
/// See <a href="https://corefork.telegram.org/constructor/phoneCallRequested" />
///</summary>
[TlObject(0x14b0ed0c)]
public sealed class TPhoneCallRequested : IPhoneCall
{
    public uint ConstructorId => 0x14b0ed0c;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether this is a video call
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Video { get; set; }

    ///<summary>
    /// Phone call ID
    ///</summary>
    public long Id { get; set; }

    ///<summary>
    /// Access hash
    ///</summary>
    public long AccessHash { get; set; }

    ///<summary>
    /// When was the phone call created
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// ID of the creator of the phone call
    ///</summary>
    public long AdminId { get; set; }

    ///<summary>
    /// ID of the other participant of the phone call
    ///</summary>
    public long ParticipantId { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for key exchange</a>
    ///</summary>
    public byte[] GAHash { get; set; }

    ///<summary>
    /// Call protocol info to be passed to libtgvoip
    /// See <a href="https://corefork.telegram.org/type/PhoneCallProtocol" />
    ///</summary>
    public MyTelegram.Schema.IPhoneCallProtocol Protocol { get; set; }

    public void ComputeFlag()
    {
        if (Video) { Flags[6] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Id);
        writer.Write(AccessHash);
        writer.Write(Date);
        writer.Write(AdminId);
        writer.Write(ParticipantId);
        writer.Write(GAHash);
        writer.Write(Protocol);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[6]) { Video = true; }
        Id = reader.ReadInt64();
        AccessHash = reader.ReadInt64();
        Date = reader.ReadInt32();
        AdminId = reader.ReadInt64();
        ParticipantId = reader.ReadInt64();
        GAHash = reader.ReadBytes();
        Protocol = reader.Read<MyTelegram.Schema.IPhoneCallProtocol>();
    }
}