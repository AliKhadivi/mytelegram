﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
/// Obtain a list of <a href="https://corefork.telegram.org/api/stars#buying-or-gifting-stars">Telegram Stars gift options »</a> as <a href="https://corefork.telegram.org/constructor/starsGiftOption">starsGiftOption</a> constructors.
/// See <a href="https://corefork.telegram.org/method/payments.getStarsGiftOptions" />
///</summary>
[TlObject(0xd3c96bc8)]
public sealed class RequestGetStarsGiftOptions : IRequest<TVector<MyTelegram.Schema.IStarsGiftOption>>
{
    public uint ConstructorId => 0xd3c96bc8;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Receiver of the gift (optional).
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser? UserId { get; set; }

    public void ComputeFlag()
    {
        if (UserId != null) { Flags[0] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[0]) { writer.Write(UserId); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { UserId = reader.Read<MyTelegram.Schema.IInputUser>(); }
    }
}
