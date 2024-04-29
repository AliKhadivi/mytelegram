﻿using IPeerSettings = MyTelegram.Schema.IPeerSettings;

namespace MyTelegram.Messenger.TLObjectConverters.Interfaces;

public interface IPeerSettingsConverter : ILayeredConverter
{
    IPeerSettings ToPeerSettings(long selfUserId, long targetUserId, IPeerSettingsReadModel? readModel,
        ContactType? contactType);
}