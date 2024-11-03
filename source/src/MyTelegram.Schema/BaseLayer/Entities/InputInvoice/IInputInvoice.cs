﻿// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// An invoice
/// See <a href="https://corefork.telegram.org/constructor/InputInvoice" />
///</summary>
[JsonDerivedType(typeof(TInputInvoiceMessage), nameof(TInputInvoiceMessage))]
[JsonDerivedType(typeof(TInputInvoiceSlug), nameof(TInputInvoiceSlug))]
[JsonDerivedType(typeof(TInputInvoicePremiumGiftCode), nameof(TInputInvoicePremiumGiftCode))]
[JsonDerivedType(typeof(TInputInvoiceStars), nameof(TInputInvoiceStars))]
[JsonDerivedType(typeof(TInputInvoiceChatInviteSubscription), nameof(TInputInvoiceChatInviteSubscription))]
[JsonDerivedType(typeof(TInputInvoiceStarGift), nameof(TInputInvoiceStarGift))]
public interface IInputInvoice : IObject
{

}
