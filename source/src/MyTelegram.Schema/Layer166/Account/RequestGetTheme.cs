﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Get theme information
/// <para>Possible errors</para>
/// Code Type Description
/// 400 THEME_FORMAT_INVALID Invalid theme format provided.
/// 400 THEME_INVALID Invalid theme provided.
/// See <a href="https://corefork.telegram.org/method/account.getTheme" />
///</summary>
[TlObject(0x3a5869ec)]
public sealed class RequestGetTheme : IRequest<MyTelegram.Schema.ITheme>
{
    public uint ConstructorId => 0x3a5869ec;
    ///<summary>
    /// Theme format, a string that identifies the theming engines supported by the client
    ///</summary>
    public string Format { get; set; }

    ///<summary>
    /// Theme
    /// See <a href="https://corefork.telegram.org/type/InputTheme" />
    ///</summary>
    public MyTelegram.Schema.IInputTheme Theme { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Format);
        writer.Write(Theme);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Format = reader.ReadString();
        Theme = reader.Read<MyTelegram.Schema.IInputTheme>();
    }
}