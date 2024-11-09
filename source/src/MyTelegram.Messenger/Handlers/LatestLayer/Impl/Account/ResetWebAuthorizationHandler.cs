﻿// ReSharper disable All

namespace MyTelegram.Handlers.Account;

///<summary>
/// Log out an active web <a href="https://corefork.telegram.org/widgets/login">telegram login</a> session
/// <para>Possible errors</para>
/// Code Type Description
/// 400 HASH_INVALID The provided hash is invalid.
/// See <a href="https://corefork.telegram.org/method/account.resetWebAuthorization" />
///</summary>
internal sealed class ResetWebAuthorizationHandler(ICommandBus commandBus,
    IQueryProcessor queryProcessor,
    IObjectMessageSender messageSender,
    ILogger<ResetAuthorizationHandler> logger,
    IEventBus eventBus) : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestResetWebAuthorization, IBool>,
    Account.IResetWebAuthorizationHandler
{
    protected override async Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestResetWebAuthorization obj)
    {

        var deviceReadModel = await queryProcessor
            .ProcessAsync(new GetDeviceByHashQuery(input.UserId, obj.Hash));
        if (deviceReadModel != null)
        {
            await eventBus.PublishAsync(new UnRegisterAuthKeyEvent(deviceReadModel.PermAuthKeyId));
        }
        else
        {
            logger.LogWarning("Cannot find device, userId: {UserId}, hash: {Hash}", input.UserId, obj.Hash);
        }

        return new TBoolTrue();
    }
}
