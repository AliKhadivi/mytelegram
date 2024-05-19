﻿using MyTelegram.GatewayServer.NativeAot;

namespace MyTelegram.GatewayServer.Extensions;

public static class MyTelegramGatewayServerExtensions
{
    public static void AddMyTelegramGatewayServer(this IServiceCollection services)
    {
        services.AddSingleton<IClientManager, ClientManager>();
        services.AddSingleton(typeof(IMessageQueueProcessor<>), typeof(MessageQueueProcessor2<>));

        services.AddSingleton<IMessageIdHelper, MessageIdHelper>();
        services.AddTransient<IAesHelper, AesHelper>();
        services.AddTransient<IMtpMessageEncoder, MtpMessageEncoder>();
        services.AddTransient<IFirstPacketParser, FirstPacketParser>();
        services.AddTransient<IUnencryptedMessageParser, UnencryptedMessageParser>();
        services.AddTransient<IEncryptedMessageParser, EncryptedMessageParser>();
        services.AddTransient<IDataProcessor<UnencryptedMessage>, MessageDataProcessor>();
        services.AddTransient<IDataProcessor<EncryptedMessage>, MessageDataProcessor>();

        services.AddTransient<IMtpMessageParser, MtpMessageParser>();
        services.AddTransient<IMtpMessageDispatcher, MtpMessageDispatcher>();
        services.AddTransient<EncryptedMessageResponseEventHandler>();
        services.AddTransient<UnencryptedMessageResponseEventHandler>();
        services.AddTransient<AuthKeyNotFoundEventHandler>();
        services.AddTransient<TransportErrorEventHandler>();
        services.AddTransient<IClientDataSender, ClientDataSender>();
        services.AddTransient<IProxyProtocolParser, ProxyProtocolParser>();

        services.AddTransient<IDataProcessor<ClientDisconnectedEvent>, ClientDisconnectedDataProcessor>();

        services.FixNativeAotIssues();
    }

    public static void ConfigureEventBus(this IEventBus eventBus)
    {
        eventBus.Subscribe<MyTelegram.Core.EncryptedMessageResponse, EncryptedMessageResponseEventHandler>();
        eventBus.Subscribe<MyTelegram.Core.UnencryptedMessageResponse, UnencryptedMessageResponseEventHandler>();
        eventBus.Subscribe<AuthKeyNotFoundEvent, AuthKeyNotFoundEventHandler>();
        eventBus.Subscribe<TransportErrorEvent, TransportErrorEventHandler>();
    }
}
