﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// The full list of usable <a href="https://corefork.telegram.org/api/effects">animated message effects »</a> hasn't changed.
/// See <a href="https://corefork.telegram.org/constructor/messages.availableEffectsNotModified" />
///</summary>
[TlObject(0xd1ed9a5b)]
public sealed class TAvailableEffectsNotModified : IAvailableEffects
{
    public uint ConstructorId => 0xd1ed9a5b;


    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);

    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {

    }
}