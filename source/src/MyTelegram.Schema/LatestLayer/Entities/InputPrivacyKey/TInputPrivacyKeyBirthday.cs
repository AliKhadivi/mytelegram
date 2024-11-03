﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Whether the user can see our birthday.
/// See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyBirthday" />
///</summary>
[TlObject(0xd65a11cc)]
public sealed class TInputPrivacyKeyBirthday : IInputPrivacyKey
{
    public uint ConstructorId => 0xd65a11cc;


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