﻿// ReSharper disable All

using TPeerSettings = MyTelegram.Schema.TPeerSettings;

namespace MyTelegram.Handlers.Messages;

///<summary>
/// Get peer settings
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getPeerSettings" />
///</summary>
internal sealed class GetPeerSettingsHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetPeerSettings, MyTelegram.Schema.Messages.IPeerSettings>,
    Messages.IGetPeerSettingsHandler
{
    private readonly IObjectMapper _objectMapper;
    private readonly IPeerHelper _peerHelper;
    private readonly IPeerSettingsAppService _peerSettingsAppService;
    private readonly IQueryProcessor _queryProcessor;
    private readonly IAccessHashHelper _accessHashHelper;
    private readonly ILayeredService<IPeerSettingsConverter> _layeredService;
    public GetPeerSettingsHandler(IPeerSettingsAppService peerSettingsAppService,
        IPeerHelper peerHelper,
        IObjectMapper objectMapper,
        IQueryProcessor queryProcessor,
        IAccessHashHelper accessHashHelper, ILayeredService<IPeerSettingsConverter> layeredService)
    {
        _peerSettingsAppService = peerSettingsAppService;
        _peerHelper = peerHelper;
        _objectMapper = objectMapper;
        _queryProcessor = queryProcessor;
        _accessHashHelper = accessHashHelper;
        _layeredService = layeredService;
    }

    protected override async Task<MyTelegram.Schema.Messages.IPeerSettings> HandleCoreAsync(IRequestInput input,
        RequestGetPeerSettings obj)
    {
        await _accessHashHelper.CheckAccessHashAsync(obj.Peer);
        var userId = input.UserId;
        var peer = _peerHelper.GetPeer(obj.Peer, userId);
        if (peer.PeerId == MyTelegramServerDomainConsts.OfficialUserId || peer.PeerType == PeerType.Self)
        {
            return new MyTelegram.Schema.Messages.TPeerSettings
            {
                Chats = new(),
                Users = new(),
                Settings = new Schema.TPeerSettings()
            };
        }

        //IContactReadModel? contactReadModel = null;
        ContactType? contactType = null;
        if (peer.PeerType == PeerType.User)
        {
            //contactReadModel = await _queryProcessor.ProcessAsync(new GetContactQuery(userId, peer.PeerId));
            var contactReadModels =
                await _queryProcessor.ProcessAsync(
                    new GetContactListBySelfIdAndTargetUserIdQuery(input.UserId, peer.PeerId));
            switch (contactReadModels.Count)
            {
                case 1:
                    contactType = ContactType.Unilateral;
                    break;
                case 2:
                    contactType = ContactType.Mutual;
                    break;
            }
        }

        var r = await _peerSettingsAppService.GetPeerSettingsAsync(userId, peer.PeerId);
        var settings = _layeredService.GetConverter(input.Layer).ToPeerSettings(peer.PeerId, r, contactType);

        if (r == null && peer.PeerType == PeerType.Channel)
        {
            settings = new TPeerSettings();
        }

        var peerSettings = new MyTelegram.Schema.Messages.TPeerSettings
        {
            Chats = new TVector<IChat>(),
            Users = new TVector<IUser>(),
            Settings = settings
        };

        return peerSettings;
    }
}
