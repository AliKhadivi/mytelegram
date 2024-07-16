﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/starsTopupOption" />
///</summary>
[TlObject(0xbd915c0)]
public sealed class TStarsTopupOption : IStarsTopupOption
{
    public uint ConstructorId => 0xbd915c0;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// &nbsp;
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Extended { get; set; }

    ///<summary>
    /// &nbsp;
    ///</summary>
    public long Stars { get; set; }

    ///<summary>
    /// &nbsp;
    ///</summary>
    public string? StoreProduct { get; set; }

    ///<summary>
    /// &nbsp;
    ///</summary>
    public string Currency { get; set; }

    ///<summary>
    /// &nbsp;
    ///</summary>
    public long Amount { get; set; }

    public void ComputeFlag()
    {
        if (Extended) { Flags[1] = true; }
        if (StoreProduct != null) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Stars);
        if (Flags[0]) { writer.Write(StoreProduct); }
        writer.Write(Currency);
        writer.Write(Amount);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[1]) { Extended = true; }
        Stars = reader.ReadInt64();
        if (Flags[0]) { StoreProduct = reader.ReadString(); }
        Currency = reader.ReadString();
        Amount = reader.ReadInt64();
    }
}