using FoodSpecialsUI.Models;
using GoogleMaps.LocationServices;
using System;
using System.Globalization;
using System.Linq;

public static class Utils
{
    private static HillBrosInc_FoodSpecialsEntities db = new HillBrosInc_FoodSpecialsEntities();

    //public static string GetStringValue(string stringKey)
    //{
    //    var localString = db.LocalStrings.FirstOrDefault(x => x.String_Key == stringKey);
    //    return localString != null ? localString.String_Value : stringKey;
    //}

    public static TimeSpan ConvertStringToTimespan(string value)
    {
        return DateTime.ParseExact(value, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
    }

    public static string ConvertTimespanToString(TimeSpan timespan)
    {
        return (DateTime.Today + timespan).ToString("hh:mm tt");
    }

    public static string ConvertTimespanToString(TimeSpan? timespan)
    {
        if (timespan != null)
        {
            return (DateTime.Today + timespan.Value).ToString("hh:mm tt");
        }
        return string.Empty;
    }

    public static MapPoint GetCoordinatesForAddress(string address)
    {
        var locationService = new GoogleLocationService();
        return locationService.GetLatLongFromAddress(address);
    }
}
