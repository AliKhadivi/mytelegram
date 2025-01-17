﻿// ReSharper disable All

namespace MyTelegram.Handlers.Users;

///<summary>
/// Returns extended user info by ID.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 USERNAME_OCCUPIED The provided username is already occupied.
/// 500 USERNAME_UNSYNCHRONIZED &nbsp;
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// See <a href="https://corefork.telegram.org/method/users.getFullUser" />
///</summary>
internal sealed class GetFullUserHandler(
    IPeerHelper peerHelper,
    IQueryProcessor queryProcessor,
    IUserAppService userAppService,
    ILayeredService<IUserConverter> layeredUserService,
    IAccessHashHelper accessHashHelper,
    IPeerSettingsAppService peerSettingsAppService,
    IPhotoAppService photoAppService,
    IPrivacyAppService privacyAppService)
    : RpcResultObjectHandler<MyTelegram.Schema.Users.RequestGetFullUser,
            MyTelegram.Schema.Users.IUserFull>,
        Users.IGetFullUserHandler
{
    //private readonly ITlUserConverter _userConverter;

    protected override async Task<MyTelegram.Schema.Users.IUserFull> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Users.RequestGetFullUser obj)
    {
        await accessHashHelper.CheckAccessHashAsync(obj.Id);

        var userId = input.UserId;
        var targetPeer = peerHelper.GetPeer(obj.Id, userId);
        var user = await userAppService.GetAsync(targetPeer.PeerId);
        if (user == null)
        {
            RpcErrors.RpcErrors400.UserIdInvalid.ThrowRpcError();
        }

        var contactReadModels =
            await queryProcessor.ProcessAsync(
                new GetContactListBySelfIdAndTargetUserIdQuery(input.UserId, targetPeer.PeerId));

        var contactType = ContactType.None;

        var contactReadModel = contactReadModels.FirstOrDefault(p =>
            p.SelfUserId == input.UserId && p.TargetUserId == targetPeer.PeerId);
        var contactReadModel2 =
            contactReadModels.FirstOrDefault(p =>
                p.SelfUserId == targetPeer.PeerId && p.TargetUserId == input.UserId);

        if (contactReadModel != null)
        {
            contactType = ContactType.Unilateral;
        }

        if (contactReadModel != null && contactReadModel2 != null)
        {
            contactType = ContactType.Mutual;
        }

        var privacies = await privacyAppService.GetPrivacyListAsync(user!.UserId);


        IBotReadModel? bot = null;
        IDocumentReadModel? botDescriptionDocumentReadModel = null;
        IPhotoReadModel? botDescriptionPhotoReadModel = null;

        var peerNotifySettingsId = PeerNotifySettingsId.Create(userId, targetPeer.PeerType, targetPeer.PeerId);

        var peerNotifySettings =
            await queryProcessor.ProcessAsync(new GetPeerNotifySettingsByIdQuery(peerNotifySettingsId));
        var peerSettings = await peerSettingsAppService.GetPeerSettingsAsync(input.UserId, targetPeer.PeerId);
        var photos = await photoAppService.GetPhotosAsync(user, contactReadModel);

        var userFull = await layeredUserService.GetConverter(input.Layer).ToUserFullAsync(
            userId,
            user,
            peerNotifySettings,
            peerSettings,
            photos,
            bot,
            botDescriptionDocumentReadModel,
            botDescriptionPhotoReadModel,
            contactReadModel,
            contactType,
            privacies);

        await SetPersonalChannelAsync(input, user, userFull);
        await SetCommonChatCountAsync(input, user, userFull);

        return userFull;
    }

    private async Task SetCommonChatCountAsync(IRequestInput input, IUserReadModel userReadModel, MyTelegram.Schema.Users.IUserFull userFull)
    {
        var count = await queryProcessor.ProcessAsync(new GetCommonChatCountQuery(input.UserId, userReadModel.UserId));
        userFull.FullUser.CommonChatsCount = count;
    }

    private async Task SetPersonalChannelAsync(IRequestInput input, IUserReadModel userReadModel, MyTelegram.Schema.Users.IUserFull userFull)
    {
        if (userReadModel.PersonalChannelId.HasValue)
        {
            var channelTopMessageId =
                await queryProcessor.ProcessAsync(
                    new GetChannelTopMessageIdQuery(userReadModel.PersonalChannelId.Value));

            if (channelTopMessageId.HasValue)
            {
                userFull.FullUser.PersonalChannelId = userReadModel.PersonalChannelId;
                userFull.FullUser.PersonalChannelMessage = channelTopMessageId.Value;
            }
        }
    }
}
