﻿// ReSharper disable All

namespace MyTelegram.Handlers.Channels;

///<summary>
/// See <a href="https://corefork.telegram.org/method/channels.setEmojiStickers" />
///</summary>
internal sealed class SetEmojiStickersHandler : RpcResultObjectHandler<MyTelegram.Schema.Channels.RequestSetEmojiStickers, IBool>,
    Channels.ISetEmojiStickersHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Channels.RequestSetEmojiStickers obj)
    {
        throw new NotImplementedException();
    }
}
