﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Contains info about successfully or unsuccessfully <a href="https://corefork.telegram.org/api/invites#direct-invites">invited »</a> users.
/// See <a href="https://corefork.telegram.org/constructor/messages.invitedUsers" />
///</summary>
[TlObject(0x7f5defa6)]
public sealed class TInvitedUsers : IInvitedUsers
{
    public uint ConstructorId => 0x7f5defa6;
    ///<summary>
    /// List of updates about successfully invited users (and eventually info about the created group)
    /// See <a href="https://corefork.telegram.org/type/Updates" />
    ///</summary>
    public MyTelegram.Schema.IUpdates Updates { get; set; }

    ///<summary>
    /// A list of users that could not be invited, along with the reason why they couldn't be invited.
    ///</summary>
    public TVector<MyTelegram.Schema.IMissingInvitee> MissingInvitees { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Updates);
        writer.Write(MissingInvitees);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Updates = reader.Read<MyTelegram.Schema.IUpdates>();
        MissingInvitees = reader.Read<TVector<MyTelegram.Schema.IMissingInvitee>>();
    }
}