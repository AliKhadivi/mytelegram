﻿namespace MyTelegram.Messenger.Services.Impl;

public class PrivacyAppService(
    ICacheManager<GlobalPrivacySettingsCacheItem> cacheManager,
    IQueryProcessor queryProcessor)
    : BaseAppService, IPrivacyAppService, ITransientDependency
{
    public Task<IReadOnlyCollection<IPrivacyReadModel>> GetPrivacyListAsync(IReadOnlyList<long> userIds)
    {
        return Task.FromResult<IReadOnlyCollection<IPrivacyReadModel>>(Array.Empty<IPrivacyReadModel>());
    }

    public Task<IReadOnlyCollection<IPrivacyReadModel>> GetPrivacyListAsync(long userId)
    {
        return GetPrivacyListAsync([userId]);
    }

    public Task ApplyPrivacyAsync(long selfUserId, long targetUserId, Action executeOnPrivacyNotMatch, List<PrivacyType> privacyTypes)
    {
        return Task.CompletedTask;
    }

    public Task ApplyPrivacyListAsync(long selfUserId, IReadOnlyList<long> targetUserIdList, Action<long> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
    {
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<IPrivacyRule>> GetPrivacyRulesAsync(long selfUserId,
        IInputPrivacyKey key)
    {
        return Task.FromResult<IReadOnlyList<IPrivacyRule>>(Array.Empty<IPrivacyRule>());

    }

    public Task SetGlobalPrivacySettingsAsync(long selfUserId, GlobalPrivacySettings globalPrivacySettings)
    {
        throw new NotImplementedException();
    }

    public async Task<GlobalPrivacySettingsCacheItem?> GetGlobalPrivacySettingsAsync(long userId)
    {
        var cacheKey = GlobalPrivacySettingsCacheItem.GetCacheKey(userId);
        var item = await cacheManager.GetAsync(cacheKey);
        var globalPrivacySettings = await queryProcessor.ProcessAsync(new GetGlobalPrivacySettingsQuery(userId));
        if (globalPrivacySettings != null)
        {
            item = new GlobalPrivacySettingsCacheItem(globalPrivacySettings.ArchiveAndMuteNewNoncontactPeers,
                globalPrivacySettings.KeepArchivedUnmuted, globalPrivacySettings.KeepArchivedFolders,
                globalPrivacySettings.HideReadMarks, globalPrivacySettings.NewNoncontactPeersRequirePremium);
            await cacheManager.SetAsync(cacheKey, item);
        }
        return item;
    }

    public Task<SetPrivacyOutput> SetPrivacyAsync(RequestInfo requestInfo,
        long selfUserId,
        IInputPrivacyKey key,
        IReadOnlyList<IInputPrivacyRule> ruleList)
    {
        return Task.FromResult(new SetPrivacyOutput(new List<IPrivacyRule>()));
    }
}