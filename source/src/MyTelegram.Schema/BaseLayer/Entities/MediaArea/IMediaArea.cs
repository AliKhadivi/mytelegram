﻿// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/stories#media-areas">story media area »</a>
/// See <a href="https://corefork.telegram.org/constructor/MediaArea" />
///</summary>
[JsonDerivedType(typeof(TMediaAreaVenue), nameof(TMediaAreaVenue))]
[JsonDerivedType(typeof(TInputMediaAreaVenue), nameof(TInputMediaAreaVenue))]
[JsonDerivedType(typeof(TMediaAreaGeoPoint), nameof(TMediaAreaGeoPoint))]
[JsonDerivedType(typeof(TMediaAreaSuggestedReaction), nameof(TMediaAreaSuggestedReaction))]
[JsonDerivedType(typeof(TMediaAreaChannelPost), nameof(TMediaAreaChannelPost))]
[JsonDerivedType(typeof(TInputMediaAreaChannelPost), nameof(TInputMediaAreaChannelPost))]
[JsonDerivedType(typeof(TMediaAreaUrl), nameof(TMediaAreaUrl))]
[JsonDerivedType(typeof(TMediaAreaWeather), nameof(TMediaAreaWeather))]
public interface IMediaArea : IObject
{
    ///<summary>
    /// The size and location of the media area corresponding to the widget on top of the story media.
    /// See <a href="https://corefork.telegram.org/type/MediaAreaCoordinates" />
    ///</summary>
    MyTelegram.Schema.IMediaAreaCoordinates Coordinates { get; set; }
}
