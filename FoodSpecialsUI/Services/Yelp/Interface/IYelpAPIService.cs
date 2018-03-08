using FoodSpecialsUI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodSpecialsUI.Services
{
    public interface IYelpAPIService
    {
        ////Defined in Yelp.cs
        //Task<> Search(string term, string location);

        ////Defined in Yelp.cs
        //Task<SearchResponse> Search(YelpSearchOptions options);

        //Defined in Yelp.cs
        //Task<Business> GetBusiness(string name);

        /// <summary>
        /// Takes in a location and search term and returns a list of restaurants with id and name
        /// </summary>
        /// <param name="location"></param>
        /// <param name="term"></param>
        /// <returns>iqueryable of resaurant names</returns>
        Task<IList<RestaurantDTO>> SearchRestaurantsByLocationAndTerm(string location, string term);

        /// <summary>
        /// Searches restaurant by location coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of user.</param>
        /// <param name="longitude">Longitude of user.</param>
        /// <returns>List of Business restaurants</returns>
        Task<IList<RestaurantDTO>> SearchRestaurantsByCoordinates(double latitude, double longitude, string term);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Keyword for search.</param>
        /// <param name="latitude">Latitude of user.</param>
        /// <param name="longitude">Longitude of user.</param>
        /// <returns></returns>
        Task<IList<RestaurantDTO>> GetAutocomplete(string text, double latitude, double longitude);

        /// <summary>
        /// Get the restaurants name by its Yelp Id
        /// </summary>
        /// <param name="id">Yelp Id</param>
        /// <returns>name of restaurant</returns>
        RestaurantDTO GetBusinessById(string id);

        ///// <summary>
        ///// Returns a YelpSearchOptions object
        ///// </summary>
        ///// <param name="YelpSearchOptionsGeneral">general options passed in</param>
        ///// <param name="YelpLocationOptions">location options passed in</param>
        ///// <returns>YelpSearchOptions object</returns>
        //YelpSearchOptions MakeYelpSearchOptions(YelpSearchOptionsGeneral, YelpLocationOptions YelpLocationOptions);

        ///// <summary>
        ///// Returns a YelpSearchOptions object
        ///// </summary>
        ///// <param name="term">keyword term</param>
        ///// <param name="location">the location</param>
        ///// <returns></returns>
        //YelpSearchOptions MakeYelpSearchOptions(string location, string term);

        ///// <summary>
        ///// Returns a Locations Options Object
        ///// </summary>
        ///// <param name="location">Defined in Yelp Api</param>
        ///// <param name="YelpCoordinateOptions">Additional location options</param>
        ///// <returns></returns>
        //YelpLocationOptions MakeYelpLocationOptions(string location, YelpCoordinateOptions YelpCoordinateOptions = null);

        ///// <summary>
        ///// Returns a General Options object
        ///// </summary>
        ///// <param name="term">Defined in Yelp Api</param>
        ///// <param name="sort">Defined in Yelp Api</param>
        ///// <param name="category_filter">Defined in Yelp Api</param>
        ///// <param name="offset">Defined in Yelp Api</param>
        ///// <param name="limit">Defined in Yelp Api</param>\
        ///// <param name="radius_filter">Defined in Yelp Api</param>
        ///// <param name="deals_filter">Defined in Yelp Api</param>
        ///// <returns>General Options object</returns>
        //YelpSearchOptionsGeneral MakeYelpSearchOptionsGeneral(string term, int? sort = null, string category_filter = null, int? offset = null, int? limit = null,
        //    double? radius_filter = null, bool? deals_filter = null);
    }
}
