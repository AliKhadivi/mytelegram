﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Poll
/// See <a href="https://corefork.telegram.org/constructor/poll" />
///</summary>
[TlObject(0x58747131)]
public sealed class TPoll : IPoll
{
    public uint ConstructorId => 0x58747131;
    ///<summary>
    /// ID of the poll
    ///</summary>
    public long Id { get; set; }

    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether the poll is closed and doesn't accept any more answers
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Closed { get; set; }

    ///<summary>
    /// Whether cast votes are publicly visible to all users (non-anonymous poll)
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool PublicVoters { get; set; }

    ///<summary>
    /// Whether multiple options can be chosen as answer
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool MultipleChoice { get; set; }

    ///<summary>
    /// Whether this is a quiz (with wrong and correct answers, results shown in the return type)
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Quiz { get; set; }

    ///<summary>
    /// The question of the poll (only <a href="https://corefork.telegram.org/api/premium">Premium</a> users can use <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji entities</a> here).
    /// See <a href="https://corefork.telegram.org/type/TextWithEntities" />
    ///</summary>
    public MyTelegram.Schema.ITextWithEntities Question { get; set; }

    ///<summary>
    /// The possible answers, vote using <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.
    ///</summary>
    public TVector<MyTelegram.Schema.IPollAnswer> Answers { get; set; }

    ///<summary>
    /// Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with close_date.
    ///</summary>
    public int? ClosePeriod { get; set; }

    ///<summary>
    /// Point in time (Unix timestamp) when the poll will be automatically closed. Must be at least 5 and no more than 600 seconds in the future; can't be used together with close_period.
    ///</summary>
    public int? CloseDate { get; set; }

    public void ComputeFlag()
    {
        if (Closed) { Flags[0] = true; }
        if (PublicVoters) { Flags[1] = true; }
        if (MultipleChoice) { Flags[2] = true; }
        if (Quiz) { Flags[3] = true; }
        if (/*ClosePeriod != 0 && */ClosePeriod.HasValue) { Flags[4] = true; }
        if (/*CloseDate != 0 && */CloseDate.HasValue) { Flags[5] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Id);
        writer.Write(Flags);
        writer.Write(Question);
        writer.Write(Answers);
        if (Flags[4]) { writer.Write(ClosePeriod.Value); }
        if (Flags[5]) { writer.Write(CloseDate.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Id = reader.ReadInt64();
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Closed = true; }
        if (Flags[1]) { PublicVoters = true; }
        if (Flags[2]) { MultipleChoice = true; }
        if (Flags[3]) { Quiz = true; }
        Question = reader.Read<MyTelegram.Schema.ITextWithEntities>();
        Answers = reader.Read<TVector<MyTelegram.Schema.IPollAnswer>>();
        if (Flags[4]) { ClosePeriod = reader.ReadInt32(); }
        if (Flags[5]) { CloseDate = reader.ReadInt32(); }
    }
}