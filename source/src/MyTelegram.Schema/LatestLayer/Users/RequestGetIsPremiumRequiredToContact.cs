﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Users;

///<summary>
/// Check whether we can write to the specified user (this method can only be called by non-<a href="https://corefork.telegram.org/api/premium">Premium</a> users), see <a href="https://corefork.telegram.org/api/privacy#require-premium-for-new-non-contact-users">here »</a> for more info on the full flow.
/// See <a href="https://corefork.telegram.org/method/users.getIsPremiumRequiredToContact" />
///</summary>
[TlObject(0xa622aa10)]
public sealed class RequestGetIsPremiumRequiredToContact : IRequest<TVector<bool>>
{
    public uint ConstructorId => 0xa622aa10;
    ///<summary>
    /// Users to fetch info about.
    ///</summary>
    public TVector<MyTelegram.Schema.IInputUser> Id { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Id);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Id = reader.Read<TVector<MyTelegram.Schema.IInputUser>>();
    }
}
