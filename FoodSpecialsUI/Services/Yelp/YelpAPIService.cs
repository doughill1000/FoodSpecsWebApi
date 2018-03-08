using System.Collections.Generic;
using YelpSharper;
using System.Linq;
using FoodSpecialsUI.DTOs;
using FoodSpecialsUI.Repository;
using System;
using Newtonsoft.Json;
using FoodSpecialsUI.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using YelpSharper.Models;

namespace FoodSpecialsUI.Services
{
    
    public class YelpAPIService : IYelpAPIService
    {
        #region Properties and Constructors
        private YelpSharperClient client;
        private Lazy<IFoodSpecialRepository> lazyFoodSpecRepository;

        const int numRestaurants = 50;
        const int yelpLimit = 50;
        const string CATEGORIES = "restaurants,nightlife";

        public YelpAPIService(Lazy<IFoodSpecialRepository> lazyFoodSpecRepository)
        {
            this.lazyFoodSpecRepository = lazyFoodSpecRepository;
            client = new YelpSharperClient();
            var token = client.GetToken(YelpConfig.AppId, YelpConfig.AppSecret);
            client.AccessToken = token.AccessToken;
        }
        #endregion

        #region Public methods

        ///<inheritdoc>
        public async Task<IList<RestaurantDTO>> SearchRestaurantsByLocationAndTerm(string location, string term)
        {
            //Call to yelp
            var result = await client.SearchAsync(new
            {
                term = term,
                location = location,                
                limit = yelpLimit.ToString(),
                radius = "40000",
                categories = CATEGORIES
            }).ConfigureAwait(false);

            //Call to specs db
            return await GetRestaurantsWithSpecs(result.Businesses);
        }

        ///<inheritdoc>
        public async Task<IList<RestaurantDTO>> SearchRestaurantsByCoordinates(double latitude, double longitude, string term)
        {
            //Call to yelp
            var businesses = new List<Business>();
            var offset = 0;
            var sortBy = string.IsNullOrEmpty(term) ? "distance" : "best_match";
            //Set numRestaurants to number you would like, only 50 retrievable at a time.
            for (var i = 0; i < numRestaurants/yelpLimit; i++)
            {
                var result = await client.SearchAsync(new
                {
                    term = term,
                    latitude = latitude.ToString(),
                    longitude = longitude.ToString(),
                    offset = offset,
                    limit = yelpLimit.ToString(),
                    radius = "40000",
                    sort_by = sortBy,
                    categories = CATEGORIES
                }).ConfigureAwait(false);
                businesses.AddRange(result.Businesses);

                offset += yelpLimit;
            }

            //Call to specs db
            return await GetRestaurantsWithSpecs(businesses).ConfigureAwait(false);
        }

        ///<inheritdoc>
        public async Task<IList<RestaurantDTO>> GetAutocomplete(string text, double latitude, double longitude)
        {
            //Call to yelp
            var result = await client.AutocompleteAsync(new
            {
                text = text,
                latitude = latitude.ToString(),
                longitude = longitude.ToString()
            }).ConfigureAwait(false);

            //Call to specs db
            return await GetRestaurantsWithSpecs(result.Businesses);
        } 

        ///<inheritdoc>
        public RestaurantDTO GetBusinessById(string id)
        {
            //Call to yelp then specs db
            return GetRestaurantWithSpecs(client.GetBusiness(id));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a restaurant with specs populated from yelp results.
        /// </summary>
        /// <param name="business">The yelp business</param>
        /// <returns>Restaurant object</returns>
        private RestaurantDTO GetRestaurantWithSpecs(Business business)
        {
            var serialized = JsonConvert.SerializeObject(business);
            var restaurant = JsonConvert.DeserializeObject<RestaurantDTO>(serialized);

            restaurant.FoodSpecials = lazyFoodSpecRepository.Value.GetFoodSpecialsForRestaurant(business.Id).ToList();

            return restaurant;
        }

        /// <summary>
        /// Gets the Restaurant DTO objects with specials populated from yelp results.
        /// </summary>
        /// <param name="businesses">The yelp businesses</param>
        /// <returns>List of restaurant objects</returns>
        private async Task<IList<RestaurantDTO>> GetRestaurantsWithSpecs(IList<Business> businesses)
        {
            var restaurants = CastBusinessesToRestaurants(businesses);

            var foodSpecs = await lazyFoodSpecRepository.Value.GetAll(restaurants.Select(x => x.Id)).ToListAsync();
            foreach (var restaurant in restaurants)
            {
                restaurant.FoodSpecials = new List<FoodSpecial>(foodSpecs.Where(x => x.RestaurantId == restaurant.Id));
            }

            return restaurants;
        }

        /// <summary>
        /// Casts as list of businesses to restaurants. Uses JSON serialization.
        /// </summary>
        /// <param name="businesses">Businesses from Yelp search.</param>
        /// <returns>List of restuarant objects</returns>
        private IList<RestaurantDTO> CastBusinessesToRestaurants(IList<Business> businesses)
        {
            var serialized = JsonConvert.SerializeObject(businesses);
            return JsonConvert.DeserializeObject<IList<RestaurantDTO>>(serialized);
        }
        #endregion
    }
}