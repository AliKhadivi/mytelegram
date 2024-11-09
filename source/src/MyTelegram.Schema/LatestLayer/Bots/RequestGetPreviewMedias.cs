﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Bots;

///<summary>
/// Fetch <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app previews, see here »</a> for more info.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_INVALID This is not a valid bot.
/// See <a href="https://corefork.telegram.org/method/bots.getPreviewMedias" />
///</summary>
[TlObject(0xa2a5594d)]
public sealed class RequestGetPreviewMedias : IRequest<TVector<MyTelegram.Schema.IBotPreviewMedia>>
{
    public uint ConstructorId => 0xa2a5594d;
    ///<summary>
    /// The bot that owns the Main Mini App.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Bot);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Bot = reader.Read<MyTelegram.Schema.IInputUser>();
    }
}
