﻿namespace MyTelegram.Messenger.Services.Impl;

public class IdGenerator(
    IHiLoValueGeneratorCache cache,
    IHiLoValueGeneratorFactory factory,
    IQueryProcessor queryProcessor,
    IHiLoStateBlockSizeHelper stateBlockSizeHelper,
    ILogger<IdGenerator> logger)
    : IIdGenerator
{
    public async Task<int> NextIdAsync(IdType idType,
        long id,
        int step = 1,
        CancellationToken cancellationToken = default)
    {
        return (int)await NextLongIdAsync(idType, id, step, cancellationToken);
    }

    public async Task<long> NextLongIdAsync(IdType idType,
        long id = 0,
        int step = 1,
        CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();

        HiLoValueGeneratorState state;
        if (idType == IdType.MessageId)
        {
            state = await GetMessageIdStateAsync(idType, id);
        }
        else
        {
            state = cache.GetOrAdd(idType, id);
        }

        var generator = factory.Create(state);
        var nextId = await generator.NextAsync(idType, id, cancellationToken);
        sw.Stop();

        if (sw.Elapsed.TotalMilliseconds > 100)
        {
            logger.LogWarning("[{Timespan}] Generate id too slow, idType: {IdType}, id: {Id}", sw.Elapsed, idType, id);
        }

        return nextId + GetInitId(idType);
    }

    private static long GetInitId(IdType idType)
    {
        return idType switch
        {
            IdType.ChannelId => MyTelegramServerDomainConsts.ChannelInitId,
            IdType.UserId => MyTelegramServerDomainConsts.UserIdInitId + 10000, // First 10000 for testing
            IdType.BotUserId => MyTelegramServerDomainConsts.BotUserInitId,
            IdType.ChatId => MyTelegramServerDomainConsts.ChatIdInitId,
            IdType.Pts => MyTelegramServerDomainConsts.PtsInitId,
            _ => 0
        };
    }

    private async Task<int> GetMaxMessageIdAsync(long ownerPeerId)
    {
        int? maxId = await queryProcessor.ProcessAsync(new GetMaxMessageIdByPeerIdQuery(ownerPeerId));

        return maxId ?? 0;
    }
    private async Task<HiLoValueGeneratorState> GetMessageIdStateAsync(IdType idType, long id)
    {
        var maxId = await GetMaxMessageIdAsync(id);
        if (maxId > 0)
        {
            var blockSize = stateBlockSizeHelper.GetBlockSize(idType);
            var high = maxId / blockSize;
            return await cache.GetOrAddAsync(idType, id, () => Task.FromResult(new HiLoValueGeneratorState(blockSize, maxId, (high + 1) * blockSize + 1)));
        }

        return cache.GetOrAdd(idType, id);
    }
}