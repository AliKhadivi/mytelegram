﻿// ReSharper disable All

namespace MyTelegram.Handlers.Auth;

///<summary>
/// Generate a login token, for <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.<br>
/// The generated login token should be encoded using base64url, then shown as a <code>tg://login?token=base64encodedtoken</code> <a href="https://corefork.telegram.org/api/links#qr-code-login-links">deep link »</a> in the QR code.For more info, see <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 API_ID_INVALID API ID invalid.
/// 400 API_ID_PUBLISHED_FLOOD This API id was published somewhere, you can't use it now.
/// See <a href="https://corefork.telegram.org/method/auth.exportLoginToken" />
///</summary>
internal sealed class ExportLoginTokenHandler(
    ICacheHelper<long, long> cacheHelper,
    ICommandBus commandBus,
    IQueryProcessor queryProcessor,
    IRandomHelper randomHelper,
    ILogger<ExportLoginTokenHandler> logger,
    IEventBus eventBus,
    ILayeredService<IAuthorizationConverter> layeredService,
    ILayeredService<IUserConverter> layeredUserService,
    IPhotoAppService photoAppService)
    : RpcResultObjectHandler<MyTelegram.Schema.Auth.RequestExportLoginToken, MyTelegram.Schema.Auth.ILoginToken>,
        Auth.IExportLoginTokenHandler
{
    protected override async Task<ILoginToken> HandleCoreAsync(IRequestInput input,
        RequestExportLoginToken obj)
    {
        if (cacheHelper.TryRemove(input.AuthKeyId, out var userId))
        {
            await eventBus
                .PublishAsync(new BindUidToSessionEvent(userId, input.AuthKeyId, input.PermAuthKeyId));

            var userReadModel = await queryProcessor
                .ProcessAsync(new GetUserByIdQuery(userId));
            var photos = await photoAppService.GetPhotosAsync(userReadModel);
            ILayeredUser? user = userReadModel == null ? null : layeredUserService.GetConverter(input.Layer).ToUser(userReadModel.UserId, userReadModel, photos);
            return new TLoginTokenSuccess
            {
                Authorization = layeredService.GetConverter(input.Layer).CreateAuthorization(user)
            };
        }

        var token = new byte[32];
        randomHelper.NextBytes(token);
        var expireDate = DateTime.UtcNow.AddSeconds(MyTelegramServerDomainConsts.QrCodeExpireSeconds).ToTimestamp();
        var qrCodeId = QrCodeId.Create(BitConverter.ToString(token));
        var command = new ExportLoginTokenCommand(qrCodeId,
            input.ToRequestInfo(),
            input.AuthKeyId,
            input.PermAuthKeyId,
            token,
            expireDate,
            obj.ExceptIds.ToList());
        await commandBus.PublishAsync(command);

        return null!;
    }
}
