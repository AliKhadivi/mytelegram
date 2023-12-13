﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Contacts;

///<summary>
/// Full list of blocked users.
/// See <a href="https://corefork.telegram.org/constructor/contacts.blocked" />
///</summary>
[TlObject(0xade1591)]
public sealed class TBlocked : IBlocked
{
    public uint ConstructorId => 0xade1591;
    ///<summary>
    /// List of blocked users
    ///</summary>
    public TVector<MyTelegram.Schema.IPeerBlocked> Blocked { get; set; }

    ///<summary>
    /// Blocked chats
    ///</summary>
    public TVector<MyTelegram.Schema.IChat> Chats { get; set; }

    ///<summary>
    /// List of users
    ///</summary>
    public TVector<MyTelegram.Schema.IUser> Users { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Blocked);
        writer.Write(Chats);
        writer.Write(Users);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Blocked = reader.Read<TVector<MyTelegram.Schema.IPeerBlocked>>();
        Chats = reader.Read<TVector<MyTelegram.Schema.IChat>>();
        Users = reader.Read<TVector<MyTelegram.Schema.IUser>>();
    }
}