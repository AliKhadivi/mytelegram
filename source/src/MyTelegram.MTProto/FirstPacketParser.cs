﻿namespace MyTelegram.MTProto;

public class FirstPacketParser(
    ILogger<FirstPacketParser> logger,
    IAesHelper aesHelper)
    : IFirstPacketParser
{
    private const byte AbridgedFlag = 0xef;
    private const byte IntermediateFlag = 0xee;

    private static readonly byte[] AbridgedBytes = { AbridgedFlag, AbridgedFlag, AbridgedFlag, AbridgedFlag };

    private static readonly byte[] IntermediateBytes =
        { IntermediateFlag, IntermediateFlag, IntermediateFlag, IntermediateFlag };

    public FirstPacketData Parse(ReadOnlySpan<byte> firstPacket)
    {
        if (firstPacket.Length == 4)
        {
            return ParseUnObfuscationFirstPacket(firstPacket);
        }

        if (firstPacket.Length < 64)
        {
            throw new ArgumentException($"Invalid first packet size:{firstPacket.Length}");
        }

        // https://corefork.telegram.org/mtproto/mtproto-transports#transport-obfuscation
        var nonce = firstPacket[..64];
        var sendKey = firstPacket.Slice(8, 32).ToArray();
        var sendIv = firstPacket.Slice(40, 16).ToArray();

        Span<byte> reversedBytes = stackalloc byte[48];
        firstPacket.Slice(8, 48).CopyTo(reversedBytes);
        reversedBytes.Reverse();

        var receiveKey = reversedBytes[..32].ToArray();
        var receiveIv = reversedBytes.Slice(32, 16).ToArray();
        var sendCtrState = new CtrState
        {
            Iv = sendIv
        };

        var encryptedNonce = ArrayPool<byte>.Shared.Rent(nonce.Length);
        try
        {
            nonce.CopyTo(encryptedNonce);
            aesHelper.Ctr128Encrypt(encryptedNonce, sendKey.ToArray(), sendCtrState);

            var data = new FirstPacketData
            {
                ObfuscationEnabled = true
            };

            var protocolBytes = encryptedNonce.AsSpan().Slice(56, 4);

            switch (protocolBytes)
            {
                case [AbridgedFlag, AbridgedFlag, AbridgedFlag, AbridgedFlag]:
                    data.ProtocolType = ProtocolType.Abridge;
                    break;
                case [IntermediateFlag, IntermediateFlag, IntermediateFlag, IntermediateFlag]:
                    data.ProtocolType = ProtocolType.Intermediate;
                    break;
                default:
                    logger.LogWarning("Unknown protocol:{nonce56:x} {nonce57:x} {nonce58:x} {nonce59:x}",
                        protocolBytes[0],
                        protocolBytes[1],
                        protocolBytes[2],
                        protocolBytes[3]);
                    break;
            }

            if (data.ProtocolType != ProtocolType.Unknown)
            {
                var dcId = BitConverter.ToInt16(encryptedNonce, 60);
                logger.LogInformation("[{ProtocolType}] Protocol detected,dcId:{DcId}", data.ProtocolType, dcId);
                data.SendKey = sendKey;
                data.ReceiveState = new CtrState
                {
                    Iv = receiveIv
                };
                data.ReceiveKey = receiveKey;
                data.SendState = sendCtrState;
            }

            return data;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(encryptedNonce);
        }
    }

    private FirstPacketData ParseUnObfuscationFirstPacket(ReadOnlySpan<byte> firstPacket)
    {
        var state = new FirstPacketData
        {
            ObfuscationEnabled = false
        };
        if (firstPacket.SequenceEqual(AbridgedBytes))
        {
            state.ProtocolType = ProtocolType.Abridge;
        }
        else if (firstPacket.SequenceEqual(IntermediateBytes))
        {
            state.ProtocolType = ProtocolType.Intermediate;
        }
        else
        {
            logger.LogWarning("UnKnown protocol:{Protocol}", firstPacket[0]);
        }

        logger.LogInformation("[{ProtocolType}](UnObfuscation) detected", state.ProtocolType);

        return state;
    }
}
