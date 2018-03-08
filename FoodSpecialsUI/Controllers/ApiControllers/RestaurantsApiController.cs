using System;
using System.Collections.Generic;
using System.Linq;
using FoodSpecialsUI.Services;
using FoodSpecialsUI.Constants;
using FoodSpecialsUI.DTOs;
using System.Web.Http;
using YelpSharper.Models;
using System.Threading.Tasks;

namespace FoodSpecialsUI.Controllers
{
    [Authorize(Roles = AuthConstants.Admin + "," + AuthConstants.User)]
    public class RestaurantsApiController : ApiController
    {
        #region Constructor
        private Lazy<IYelpAPIService> lazyYelpService;
        
        public RestaurantsApiController(Lazy<IYelpAPIService> lazyYelpService)
        {
            this.lazyYelpService = lazyYelpService;
        }
        #endregion

        /// <summary>
        /// Search restaurants by location and term
        /// </summary>
        /// <param name="location">The location you are searching in (address, city, state, zip)</param>
        /// <param name="term">The keyword for the restaurant (name, category)</param>
        /// <returns>List of restaurants</returns>
        /// api/RestaurantsApi/SearchRestaurantsByLocationAndTerm
        [HttpGet]
        public async Task<IList<RestaurantDTO>> SearchRestaurantsByLocationAndTerm(string location, string term)
        {
            return await lazyYelpService.Value.SearchRestaurantsByLocationAndTerm(location, term);
        }

        /// <summary>
        /// Search for restaurants near the given coordinates.
        /// </summary>
        /// <param name="latitude">Latitude for search</param>
        /// <param name="longitude">Longitude for search</param>
        /// <returns>List of restaurants</returns>
        /// api/RestaurantsApi/GetRestaurantsByCoordinates
        [HttpGet]
        public async Task<IList<RestaurantDTO>> SearchRestaurantsByCoordinates(double latitude, double longitude, string term = "")
        {
            return await lazyYelpService.Value.SearchRestaurantsByCoordinates(latitude, longitude, term);
        }

        /// <summary>
        /// Get a yelp restaurant by it's yelp id
        /// </summary>
        /// <param name="id">Yelp id</param>
        /// <returns>The restaurant</returns>
        /// api/RestaurantsApi/GetById
        [HttpGet]
        public RestaurantDTO GetById(string id)
        {
            return lazyYelpService.Value.GetBusinessById(id);
        }

        /// <summary>
        /// Search the autocomplete business results from Yelp.
        /// </summary>
        /// <param name="text">The text to base search on</param>
        /// <param name="latitude">Latitude near the restaurant being searched</param>
        /// <param name="longitude">Longitude near the restaurant being searched</param>
        /// <returns>List of restaurants</returns>
        /// api/RestaurantsApi/SearchAutocomplete
        [HttpGet]
        public async Task<IList<RestaurantDTO>> SearchAutocomplete(string text, double latitude, double longitude)
        {
            return await lazyYelpService.Value.GetAutocomplete(text, latitude, longitude);
        }

        //[System.Web.Http.HttpPost]
        //public HttpResponseException AddRestaurant(string id)
        //{
        //    try
        //    {
        //        lazyRestaurantService.Value.AddRestaurant(id);
        //        return new HttpResponseException(System.Net.HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
        //    }
        //}
    }
}