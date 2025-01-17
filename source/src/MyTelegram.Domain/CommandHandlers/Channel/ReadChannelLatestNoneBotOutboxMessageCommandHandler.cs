﻿namespace MyTelegram.Domain.CommandHandlers.Channel;

public class ReadChannelLatestNoneBotOutboxMessageCommandHandler : CommandHandler<ChannelAggregate, ChannelId,
    ReadChannelLatestNoneBotOutboxMessageCommand>
{
    public override Task ExecuteAsync(ChannelAggregate aggregate,
        ReadChannelLatestNoneBotOutboxMessageCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.ReadChannelLatestNoneBotOutboxMessage(command.RequestInfo, command.SourceCommandId);
        return Task.CompletedTask;
    }
}
