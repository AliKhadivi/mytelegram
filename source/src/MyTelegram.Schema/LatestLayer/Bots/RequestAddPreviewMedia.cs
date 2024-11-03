﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Bots;

///<summary>
/// Add a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview, see here »</a> for more info.Only owners of bots with a configured Main Mini App can use this method, see <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">see here »</a> for more info on how to check if you can invoke this method.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_INVALID This is not a valid bot.
/// See <a href="https://corefork.telegram.org/method/bots.addPreviewMedia" />
///</summary>
[TlObject(0x17aeb75a)]
public sealed class RequestAddPreviewMedia : IRequest<MyTelegram.Schema.IBotPreviewMedia>
{
    public uint ConstructorId => 0x17aeb75a;
    ///<summary>
    /// The bot that owns the Main Mini App.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }

    ///<summary>
    /// ISO 639-1 language code, indicating the localization of the preview to add.
    ///</summary>
    public string LangCode { get; set; }

    ///<summary>
    /// The photo/video preview, uploaded using <a href="https://corefork.telegram.org/method/messages.uploadMedia">messages.uploadMedia</a>.
    /// See <a href="https://corefork.telegram.org/type/InputMedia" />
    ///</summary>
    public MyTelegram.Schema.IInputMedia Media { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Bot);
        writer.Write(LangCode);
        writer.Write(Media);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Bot = reader.Read<MyTelegram.Schema.IInputUser>();
        LangCode = reader.ReadString();
        Media = reader.Read<MyTelegram.Schema.IInputMedia>();
    }
}
