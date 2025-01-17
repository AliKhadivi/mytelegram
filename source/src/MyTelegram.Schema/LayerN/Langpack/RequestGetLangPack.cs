﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Langpack.LayerN;

///<summary>
/// Get localization pack strings
/// <para>Possible errors</para>
/// Code Type Description
/// 400 LANG_CODE_NOT_SUPPORTED The specified language code is not supported.
/// 400 LANG_PACK_INVALID The provided language pack is invalid.
/// See <a href="https://corefork.telegram.org/method/langpack.getLangPack" />
///</summary>
[TlObject(0x9ab5c58e)]
public sealed class RequestGetLangPack : IRequest<ILangPackDifference>
{
    public uint ConstructorId => 0x9ab5c58e;
    ///<summary>
    /// Language code
    ///</summary>
    public string LangCode { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(LangCode);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        LangCode = reader.ReadString();
    }
}
