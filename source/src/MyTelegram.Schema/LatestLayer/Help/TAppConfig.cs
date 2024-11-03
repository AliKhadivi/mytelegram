﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Help;

///<summary>
/// Contains various <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration parameters</a>
/// See <a href="https://corefork.telegram.org/constructor/help.appConfig" />
///</summary>
[TlObject(0xdd18782e)]
public sealed class TAppConfig : IAppConfig
{
    public uint ConstructorId => 0xdd18782e;
    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    public int Hash { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/config#client-configuration">Client configuration parameters</a>
    /// See <a href="https://corefork.telegram.org/type/JSONValue" />
    ///</summary>
    public MyTelegram.Schema.IJSONValue Config { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Hash);
        writer.Write(Config);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Hash = reader.ReadInt32();
        Config = reader.Read<MyTelegram.Schema.IJSONValue>();
    }
}