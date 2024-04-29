﻿using IPeerSettings = MyTelegram.Schema.IPeerSettings;
using TPeerSettings = MyTelegram.Schema.TPeerSettings;

namespace MyTelegram.Messenger.TLObjectConverters.Impl.LatestLayer;

public class PeerSettingsConverterLatest(IObjectMapper objectMapper) : IPeerSettingsConverterLatest
{
    public int Layer => Layers.LayerLatest;
    public int RequestLayer { get; set; }

    public virtual IPeerSettings ToPeerSettings(long selfUserId, long targetUserId, IPeerSettingsReadModel? readModel,
        ContactType? contactType)
    {
        if (targetUserId == MyTelegramServerDomainConsts.OfficialUserId || selfUserId == targetUserId)
        {
            return new TPeerSettings();
        }

        var isContact = contactType == ContactType.Mutual || contactType == ContactType.Unilateral;

        var settings = new TPeerSettings
        {
            ShareContact = contactType == ContactType.Unilateral
        };

        if (readModel == null)
        {
            settings.BlockContact = !isContact;
            settings.AddContact = !isContact;

            return settings;
        }

        if (readModel.PeerSettings != null)
        {
            settings = objectMapper.Map<PeerSettings, TPeerSettings>(readModel.PeerSettings);

            if (!readModel.HiddenPeerSettingsBar)
            {
                settings.BlockContact = !isContact;
                settings.AddContact = !isContact;
            }
        }
        else
        {
            if (readModel.HiddenPeerSettingsBar)
            {
                settings.BlockContact = false;
                settings.AddContact = false;
            }
            else
            {
                settings.BlockContact = !isContact;
                settings.AddContact = !isContact;
            }
        }

        return settings;
    }
}