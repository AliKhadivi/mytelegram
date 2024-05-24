﻿// ReSharper disable All
namespace MyTelegram.Schema;

public interface ILayeredUser : IUser
{
    MyTelegram.Schema.IUserStatus? Status { get; set; }
    bool Self { get; set; }
    bool Contact { get; set; }
    string? Phone { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    int? BotInfoVersion { get; set; }
    bool BotChatHistory { get; set; }
    bool BotNochats { get; set; }
    ///<summary>
    ///See <a href="https://core.telegram.org/type/UserProfilePhoto" />
    ///</summary>
    MyTelegram.Schema.IUserProfilePhoto? Photo { get; set; }

    string? BotInlinePlaceholder { get; set; }
}