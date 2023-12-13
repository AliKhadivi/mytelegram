﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// No new themes were installed
/// See <a href="https://corefork.telegram.org/constructor/account.themesNotModified" />
///</summary>
[TlObject(0xf41eb622)]
public sealed class TThemesNotModified : IThemes
{
    public uint ConstructorId => 0xf41eb622;


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