﻿// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Contains info about a <a href="https://corefork.telegram.org/api/business#connected-bots">connected business bot »</a>.
/// See <a href="https://corefork.telegram.org/constructor/ConnectedBot" />
///</summary>
[JsonDerivedType(typeof(TConnectedBot), nameof(TConnectedBot))]
public interface IConnectedBot : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    BitArray Flags { get; set; }

    ///<summary>
    /// Whether the the bot can reply to messages it receives through the connection
    ///</summary>
    bool CanReply { get; set; }

    ///<summary>
    /// ID of the connected bot
    ///</summary>
    long BotId { get; set; }

    ///<summary>
    /// Specifies the private chats that a <a href="https://corefork.telegram.org/api/business#connected-bots">connected business bot »</a> may receive messages and interact with.<br>
    /// See <a href="https://corefork.telegram.org/type/BusinessBotRecipients" />
    ///</summary>
    MyTelegram.Schema.IBusinessBotRecipients Recipients { get; set; }
}
