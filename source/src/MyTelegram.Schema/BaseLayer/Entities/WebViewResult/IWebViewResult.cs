﻿// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Contains the webview URL with appropriate theme and user info parameters added
/// See <a href="https://corefork.telegram.org/constructor/WebViewResult" />
///</summary>
[JsonDerivedType(typeof(TWebViewResultUrl), nameof(TWebViewResultUrl))]
public interface IWebViewResult : IObject
{
    BitArray Flags { get; set; }
    bool Fullsize { get; set; }

    ///<summary>
    /// Webview session ID
    ///</summary>
    long? QueryId { get; set; }

    ///<summary>
    /// Webview URL to open
    ///</summary>
    string Url { get; set; }
}
