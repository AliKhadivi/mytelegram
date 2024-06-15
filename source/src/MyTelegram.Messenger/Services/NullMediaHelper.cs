﻿namespace MyTelegram.Messenger.Services;

// todo:impl media helper
public class NullMediaHelper : IMediaHelper
{
    public MessageType GeMessageType(IMessageMedia media)
    {
        throw new NotImplementedException();
    }

    public Task<IEncryptedFile> SaveEncryptedFileAsync(long reqMsgId, IInputEncryptedFile encryptedFile)
    {
        throw new NotImplementedException();
    }

    public Task<IMessageMedia> SaveMediaAsync(IInputMedia media)
    {
        throw new NotImplementedException();
    }

    public Task<SavePhotoResult> SavePhotoAsync(long reqMsgId, long fileId, bool hasVideo, double? videoStartTs, int parts, string name, string md5,
        IVideoSize? videoEmojiMarkup = null)
    {
        throw new NotImplementedException();
    }
}