﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Help;

///<summary>
/// Returns timezone information that may be used elsewhere in the API, such as to set <a href="https://corefork.telegram.org/api/business#opening-hours">Telegram Business opening hours »</a>.
/// See <a href="https://corefork.telegram.org/method/help.getTimezonesList" />
///</summary>
[TlObject(0x49b30240)]
public sealed class RequestGetTimezonesList : IRequest<MyTelegram.Schema.Help.ITimezonesList>
{
    public uint ConstructorId => 0x49b30240;
    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.
    ///</summary>
    public int Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Hash = reader.ReadInt32();
    }
}
