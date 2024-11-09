﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Open a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini App</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_INVALID This is not a valid bot.
/// See <a href="https://corefork.telegram.org/method/messages.requestMainWebView" />
///</summary>
[TlObject(0xc9e01e7b)]
public sealed class RequestRequestMainWebView : IRequest<MyTelegram.Schema.IWebViewResult>
{
    public uint ConstructorId => 0xc9e01e7b;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// If set, requests to open the mini app in compact mode (as opposed to fullview mode). Must be set if the <code>mode</code> parameter of the <a href="https://corefork.telegram.org/api/links#main-mini-app-links">Main Mini App link</a> is equal to <code>compact</code>.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Compact { get; set; }

    ///<summary>
    /// Currently open chat, may be <a href="https://corefork.telegram.org/constructor/inputPeerEmpty">inputPeerEmpty</a> if no chat is currently open.
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// Bot that owns the main mini app.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }

    ///<summary>
    /// Start parameter, if opening from a <a href="https://corefork.telegram.org/api/links#main-mini-app-links">Main Mini App link »</a>.
    ///</summary>
    public string? StartParam { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a>
    /// See <a href="https://corefork.telegram.org/type/DataJSON" />
    ///</summary>
    public MyTelegram.Schema.IDataJSON? ThemeParams { get; set; }

    ///<summary>
    /// Short name of the application; 0-64 English letters, digits, and underscores
    ///</summary>
    public string Platform { get; set; }

    public void ComputeFlag()
    {
        if (Compact) { Flags[7] = true; }
        if (StartParam != null) { Flags[1] = true; }
        if (ThemeParams != null) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(Bot);
        if (Flags[1]) { writer.Write(StartParam); }
        if (Flags[0]) { writer.Write(ThemeParams); }
        writer.Write(Platform);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[7]) { Compact = true; }
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Bot = reader.Read<MyTelegram.Schema.IInputUser>();
        if (Flags[1]) { StartParam = reader.ReadString(); }
        if (Flags[0]) { ThemeParams = reader.Read<MyTelegram.Schema.IDataJSON>(); }
        Platform = reader.ReadString();
    }
}
