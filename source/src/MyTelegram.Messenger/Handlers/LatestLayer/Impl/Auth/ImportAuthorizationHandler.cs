﻿// ReSharper disable All

namespace MyTelegram.Handlers.Auth;

///<summary>
/// Logs in a user using a key transmitted from his native data-center.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 AUTH_BYTES_INVALID The provided authorization is invalid.
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// See <a href="https://corefork.telegram.org/method/auth.importAuthorization" />
///</summary>
internal sealed class ImportAuthorizationHandler(
    IHashHelper hashHelper,
    IUserAppService userAppService,
    ICacheManager<string> cacheManager,
    IEventBus eventBus,
    ILayeredService<IAuthorizationConverter> layeredService,
    ILayeredService<IUserConverter> layeredUserService,
    IPhotoAppService photoAppService)
    : RpcResultObjectHandler<MyTelegram.Schema.Auth.RequestImportAuthorization, MyTelegram.Schema.Auth.IAuthorization>,
        Auth.IImportAuthorizationHandler
{
    protected override async Task<MyTelegram.Schema.Auth.IAuthorization> HandleCoreAsync(IRequestInput input,
        RequestImportAuthorization obj)
    {
        var keyBytes = hashHelper.Sha1(obj.Bytes);
        var key = BitConverter.ToString(keyBytes).Replace("-", string.Empty);
        var cacheKey = MyCacheKey.With("authorizations", key);
        var userIdText = await cacheManager.GetAsync(cacheKey);

        if (long.TryParse(userIdText, out var userId))
        {
            if (userId != obj.Id)
            {
                RpcErrors.RpcErrors400.UserIdInvalid.ThrowRpcError();
            }

            var userReadModel = await userAppService.GetAsync(userId);
            if (userReadModel == null)
            {
                RpcErrors.RpcErrors400.UserIdInvalid.ThrowRpcError();
            }

            await eventBus.PublishAsync(new BindUidToSessionEvent(userReadModel!.UserId, input.AuthKeyId, input.PermAuthKeyId));

            await cacheManager.RemoveAsync(key);

            var photos = await photoAppService.GetPhotosAsync(userReadModel);
            ILayeredUser? user = userReadModel == null ? null : layeredUserService.GetConverter(input.Layer).ToUser(input.UserId, userReadModel, photos);

            return layeredService.GetConverter(input.Layer).CreateAuthorization(user);
        }
        RpcErrors.RpcErrors400.UserIdInvalid.ThrowRpcError();
        return null!;
    }
}
