﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Help;

///<summary>
/// Name, ISO code, localized name and phone codes/patterns of all available countries
/// See <a href="https://corefork.telegram.org/constructor/help.countriesList" />
///</summary>
[TlObject(0x87d0759e)]
public sealed class TCountriesList : ICountriesList
{
    public uint ConstructorId => 0x87d0759e;
    ///<summary>
    /// Name, ISO code, localized name and phone codes/patterns of all available countries
    ///</summary>
    public TVector<MyTelegram.Schema.Help.ICountry> Countries { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    public int Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Countries);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Countries = reader.Read<TVector<MyTelegram.Schema.Help.ICountry>>();
        Hash = reader.ReadInt32();
    }
}