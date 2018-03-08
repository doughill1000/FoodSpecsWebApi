using FoodSpecialsUI.DTOs;
using FoodSpecialsUI.ViewModels;
using System.Collections.Generic;

using YelpSharper.Models;

namespace FoodSpecialsUI.Services
{
    public interface IRestaurantService
    {
        ///// <summary>
        ///// Get the restaurant view models for the Index view
        ///// </summary>
        ///// <returns>All the restaurants view models</returns>
        //IQueryable<RestaurantViewModel> MakeIndexViewModel();

        /// <summary>
        /// Adds a restaurant id from yelp
        /// </summary>
        /// <param name="id"></param>
        void AddRestaurant(string id);

        /// <summary>
        /// Gets restaurant by user's coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of user.</param>
        /// <param name="longitude">Longitude of user.</param>
        /// <returns></returns>
        IEnumerable<Business> GetRestaurantsByCoordinates(double latitude, double longitude);

        ///// <summary>
        ///// Create a restaurant
        ///// </summary>
        ///// <param name="restaurant view model"></param>
        //void CreateRestaurant(RestaurantViewModel viewModel);

        ///// <summary>
        ///// Get a restaurant by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Restaurant GetRestaurantById(int id);

        ///// <summary>
        ///// Make a view model for updating a restaurant
        ///// </summary>
        ///// <param name="id">id of the restaurant</param>
        ///// <returns>view model</returns>
        //RestaurantViewModel MakeUpdateRestaurantViewModel(int id);

        ///// <summary>
        ///// Update a restaurant
        ///// </summary>
        ///// <param name="restaurant">the restaurant</param>
        //void UpdateRestaurant(RestaurantViewModel viewModel);

        /// <summary>
        /// Makes the view model for deleting a restaurant
        /// </summary>
        /// <param name="id">id of the restaurant</param>
        /// <returns>the view model</returns>
        DeleteModalViewModel MakeDeleteRestaurantModalViewModel(int id);

        /// <summary>
        /// Delete a restaurant
        /// </summary>
        /// <param name="id">id of the restaurant</param>
        void DeleteRestaurant(int id);

        /// <summary>
        /// Get the top 20 restaurants
        /// </summary>
        /// <returns>IEnumerable of restaurants</returns>
        IEnumerable<RestaurantDTO> GetTop20Restaurants();

        /// <summary>
        /// Gets the top 20 closest restaurants
        /// </summary>
        /// <returns>IEnumerable of closest restaurants</returns>
        IEnumerable<RestaurantDTO> GetTop20ClosestRestaurants(double latitude, double longitude);

        /// <summary>
        /// Searches Yelp restaurants.
        /// </summary>
        /// <param name="term">term to search by</param>
        /// <param name="location">location to search by.</param>
        /// <returns></returns>
        IEnumerable<AddRestaurantViewModel> SearchRestaurants(string term, string location);
    }
}
