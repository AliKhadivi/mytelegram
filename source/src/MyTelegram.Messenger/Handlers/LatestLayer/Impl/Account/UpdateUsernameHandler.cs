﻿// ReSharper disable All

namespace MyTelegram.Handlers.Account;

///<summary>
/// Changes username for the current user.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 USERNAME_INVALID The provided username is not valid.
/// 400 USERNAME_NOT_MODIFIED The username was not modified.
/// 400 USERNAME_OCCUPIED The provided username is already occupied.
/// 400 USERNAME_PURCHASE_AVAILABLE The specified username can be purchased on <a href="https://fragment.com/">https://fragment.com</a>.
/// See <a href="https://corefork.telegram.org/method/account.updateUsername" />
///</summary>
internal sealed class UpdateUsernameHandler(
    ICommandBus commandBus,
    IQueryProcessor queryProcessor
)
    : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestUpdateUsername, MyTelegram.Schema.IUser>,
        Account.IUpdateUsernameHandler
{
    protected override async Task<IUser> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestUpdateUsername obj)
    {
        var oldUserName = await queryProcessor.ProcessAsync(new GetUserNameByUserIdQuery(input.UserId));
        if (string.Equals(obj.Username, oldUserName))
        {
            RpcErrors.RpcErrors400.UsernameNotModified.ThrowRpcError();
        }

        var command = new SetUserNameCommand(UserNameId.Create(obj.Username),
            input.ToRequestInfo(),
            input.UserId.ToUserPeer(),
            obj.Username,
            oldUserName
        );
        await commandBus.PublishAsync(command);

        return null!;
    }
}