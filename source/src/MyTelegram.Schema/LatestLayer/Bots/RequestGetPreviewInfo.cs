﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Bots;

///<summary>
/// Bot owners only, fetch <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview information, see here »</a> for more info.Note: technically non-owners may also invoke this method, but it will always behave exactly as <a href="https://corefork.telegram.org/method/bots.getPreviewMedias">bots.getPreviewMedias</a>, returning only previews for the current language and an empty <code>lang_codes</code> array, regardless of the passed <code>lang_code</code>, so please only use <a href="https://corefork.telegram.org/method/bots.getPreviewMedias">bots.getPreviewMedias</a> if you're not the owner of the <code>bot</code>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_INVALID This is not a valid bot.
/// See <a href="https://corefork.telegram.org/method/bots.getPreviewInfo" />
///</summary>
[TlObject(0x423ab3ad)]
public sealed class RequestGetPreviewInfo : IRequest<MyTelegram.Schema.Bots.IPreviewInfo>
{
    public uint ConstructorId => 0x423ab3ad;
    ///<summary>
    /// The bot that owns the Main Mini App.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }

    ///<summary>
    /// Fetch previews for the specified ISO 639-1 language code.
    ///</summary>
    public string LangCode { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Bot);
        writer.Write(LangCode);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Bot = reader.Read<MyTelegram.Schema.IInputUser>();
        LangCode = reader.ReadString();
    }
}
