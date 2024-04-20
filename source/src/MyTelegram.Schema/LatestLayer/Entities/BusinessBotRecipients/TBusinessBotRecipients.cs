﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/businessBotRecipients" />
///</summary>
[TlObject(0xb88cf373)]
public sealed class TBusinessBotRecipients : IBusinessBotRecipients
{
    public uint ConstructorId => 0xb88cf373;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool ExistingChats { get; set; }
    public bool NewChats { get; set; }
    public bool Contacts { get; set; }
    public bool NonContacts { get; set; }
    public bool ExcludeSelected { get; set; }
    public TVector<long>? Users { get; set; }
    public TVector<long>? ExcludeUsers { get; set; }

    public void ComputeFlag()
    {
        if (ExistingChats) { Flags[0] = true; }
        if (NewChats) { Flags[1] = true; }
        if (Contacts) { Flags[2] = true; }
        if (NonContacts) { Flags[3] = true; }
        if (ExcludeSelected) { Flags[5] = true; }
        if (Users?.Count > 0) { Flags[4] = true; }
        if (ExcludeUsers?.Count > 0) { Flags[6] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[4]) { writer.Write(Users); }
        if (Flags[6]) { writer.Write(ExcludeUsers); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { ExistingChats = true; }
        if (Flags[1]) { NewChats = true; }
        if (Flags[2]) { Contacts = true; }
        if (Flags[3]) { NonContacts = true; }
        if (Flags[5]) { ExcludeSelected = true; }
        if (Flags[4]) { Users = reader.Read<TVector<long>>(); }
        if (Flags[6]) { ExcludeUsers = reader.Read<TVector<long>>(); }
    }
}