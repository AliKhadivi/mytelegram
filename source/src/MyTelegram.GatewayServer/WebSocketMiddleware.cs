﻿namespace MyTelegram.GatewayServer;

public class WebSocketMiddleware(
    IMtpMessageParser messageParser,
    IMtpMessageDispatcher messageDispatcher,
    IClientManager clientManager,
    IClientDataSender clientDataSender,
    IMessageQueueProcessor<ClientDisconnectedEvent> messageQueueProcessor)
    : IMiddleware
{
    private readonly string _subProtocol = "binary";

    private readonly string[] _allowedWsPaths = ["/apiws", "/apiws_premium", "/apiws_test"];
    private bool _isWebSocketConnected;

    public async Task InvokeAsync(HttpContext context,
        RequestDelegate next)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            if (_allowedWsPaths.Contains(context.Request.Path.Value ?? string.Empty))
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync(_subProtocol);
                _isWebSocketConnected = true;

                var proxyProtocolFeature = context.Features.Get<ProxyProtocolFeature>();
                var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
                if (proxyProtocolFeature != null)
                {
                    clientIp = proxyProtocolFeature.SourceIp.ToString();
                }
                var connectionTypeFeature = context.Features.Get<ConnectionTypeFeature>();

                var clientData = new ClientData
                {
                    ConnectionId = context.Connection.Id,
                    WebSocket = webSocket,
                    ClientType = ClientType.WebSocket,
                    ClientIp = clientIp,
                    ConnectionType = connectionTypeFeature?.ConnectionType ?? ConnectionType.Generic
                };
                clientManager.AddClient(context.Connection.Id, clientData);

                await ProcessWebSocketAsync(webSocket, clientData);
            }
        }
        else
        {
            await next(context);
        }
    }

    private Task ProcessDataAsync(IMtpMessage mtpMessage,
        ClientData clientData)
    {
        if (clientData.IsFirstPacketParsed)
        {
            mtpMessage.ConnectionId = clientData.ConnectionId;
            mtpMessage.ClientIp = clientData.ClientIp;
            return messageDispatcher.DispatchAsync(mtpMessage);
        }

        return Task.CompletedTask;
    }

    private async Task ProcessWebSocketAsync(WebSocket webSocket,
        ClientData clientData)
    {
        var pipe = new Pipe();
        var writeTask = WritePipeAsync(webSocket, pipe.Writer);
        var readTask = ReadPipeAsync(pipe.Reader, clientData);
        var processResponseQueueTask = ProcessResponseQueueAsync(clientData);
        await Task.WhenAll(writeTask, readTask, processResponseQueueTask);
        clientManager.RemoveClient(clientData.ConnectionId);
        messageQueueProcessor.Enqueue(new ClientDisconnectedEvent(clientData.ConnectionId, clientData.AuthKeyId, 0), clientData.AuthKeyId);
    }

    private async Task ProcessResponseQueueAsync(ClientData clientData)
    {
        var queue = clientData.ResponseQueue;
        while (await queue.Reader.WaitToReadAsync() && _isWebSocketConnected)
        {
            while (queue.Reader.TryRead(out var response))
            {
                var encodedBytes = ArrayPool<byte>.Shared.Rent(clientDataSender.GetEncodedDataMaxLength(response.Data.Length));
                try
                {
                    var totalCount = clientDataSender.EncodeData(response, clientData, encodedBytes);
                    await clientData.WebSocket!.SendAsync(encodedBytes.AsMemory()[..totalCount], WebSocketMessageType.Binary, true, default);
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(encodedBytes);
                }
            }
        }
    }

    private async Task ReadPipeAsync(PipeReader reader,
        ClientData clientData)
    {
        while (_isWebSocketConnected)
        {
            var result = await reader.ReadAsync();
            var buffer = result.Buffer;
            if (result.IsCanceled)
            {
                break;
            }

            if (result.Buffer.IsEmpty)
            {
                continue;
            }

            if (!clientData.IsFirstPacketParsed)
            {
                messageParser.ProcessFirstUnencryptedPacket(ref buffer, clientData);
            }

            while (TryParseMessage(ref buffer, clientData, out var mtpMessage))
            {
                await ProcessDataAsync(mtpMessage, clientData);
            }

            reader.AdvanceTo(buffer.Start, buffer.End);

            if (result.IsCompleted)
            {
                break;
            }
        }

        await reader.CompleteAsync();
    }

    private bool TryParseMessage(ref ReadOnlySequence<byte> buffer,
        ClientData clientData,
        [NotNullWhen(true)] out IMtpMessage? mtpMessage)
    {
        if (buffer.Length == 0)
        {
            mtpMessage = default;
            return false;
        }

        var reader = new SequenceReader<byte>(buffer);

        if (reader.Remaining < 4)
        {
            mtpMessage = default;

            return false;
        }

        return messageParser.TryParse(ref buffer, clientData, out mtpMessage);
    }

    private async Task WritePipeAsync(WebSocket webSocket,
        PipeWriter writer)
    {
        const int minimumBufferSize = 8192 * 2;
        while (webSocket.State == WebSocketState.Open)
        {
            var memory = writer.GetMemory(minimumBufferSize);
            var receiveResult = await webSocket.ReceiveAsync(memory, CancellationToken.None);
            if (receiveResult.MessageType == WebSocketMessageType.Binary)
            {
                writer.Advance(receiveResult.Count);
                var flushResult = await writer.FlushAsync();
                if (flushResult.IsCompleted || flushResult.IsCanceled)
                {
                    break;
                }
            }
        }

        await writer.CompleteAsync();
        _isWebSocketConnected = false;
    }
}
