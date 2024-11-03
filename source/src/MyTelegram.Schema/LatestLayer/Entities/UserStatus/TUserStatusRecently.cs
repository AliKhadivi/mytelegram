﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Online status: last seen recently
/// See <a href="https://corefork.telegram.org/constructor/userStatusRecently" />
///</summary>
[TlObject(0x7b197dc8)]
public sealed class TUserStatusRecently : IUserStatus
{
    public uint ConstructorId => 0x7b197dc8;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// If set, the exact user status of this user is actually available to us, but to view it we must first purchase a <a href="https://corefork.telegram.org/api/premium">Premium</a> subscription, or allow this user to see <em>our</em> exact last online status. See <a href="https://corefork.telegram.org/constructor/privacyKeyStatusTimestamp">here »</a> for more info.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ByMe { get; set; }

    public void ComputeFlag()
    {
        if (ByMe) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);

    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { ByMe = true; }
    }
}