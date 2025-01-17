﻿namespace MyTelegram.Domain.ValueObjects;

public class SecureSecretSetting(
    byte[] salt,
    byte[] secureSecret,
    long secureSecretId)
    : ValueObject
{
    public byte[] Salt { get; init; } = salt;
    public byte[] SecureSecret { get; init; } = secureSecret;
    public long SecureSecretId { get; init; } = secureSecretId;
}
