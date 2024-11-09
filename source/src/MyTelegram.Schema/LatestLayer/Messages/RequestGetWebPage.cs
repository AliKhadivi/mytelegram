﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Get <a href="https://instantview.telegram.org/">instant view</a> page
/// <para>Possible errors</para>
/// Code Type Description
/// 400 WC_CONVERT_URL_INVALID WC convert URL invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getWebPage" />
///</summary>
[TlObject(0x8d9692a3)]
public sealed class RequestGetWebPage : IRequest<MyTelegram.Schema.Messages.IWebPage>
{
    public uint ConstructorId => 0x8d9692a3;
    ///<summary>
    /// URL of IV page to fetch
    ///</summary>
    public string Url { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>. <br><strong>Note</strong>: the usual hash generation algorithm cannot be used in this case, please re-use the <a href="https://corefork.telegram.org/constructor/webPage">webPage</a>.<code>hash</code> field returned by a previous call to the method, or pass 0 if this is the first call or if the previous call did not return a <a href="https://corefork.telegram.org/constructor/webPage">webPage</a>.
    ///</summary>
    public int Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Url);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Url = reader.ReadString();
        Hash = reader.ReadInt32();
    }
}
