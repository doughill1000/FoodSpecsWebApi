using FoodSpecialsUI.DTOs;
using FoodSpecialsUI.Models;
using FoodSpecialsUI.Repository;
using FoodSpecialsUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using YelpSharper.Models;

namespace FoodSpecialsUI.Services
{
    public class RestaurantService : IRestaurantService
    {
        #region Constructor

        private Lazy<IDailyFoodSpecialRepository> lazyDailyFoodSpecialsRepository;
        private Lazy<IRestaurantRepository> lazyRestaurantRepository;
        private Lazy<IYelpAPIService> lazyYelpAPIService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lazyRestaurantRepository"></param>
        public RestaurantService(Lazy<IDailyFoodSpecialRepository> lazyDailyFoodSpecialsRepository, Lazy<IRestaurantRepository> lazyRestaurantRepository, Lazy<IYelpAPIService> lazyYelpAPIService)
        {
            this.lazyDailyFoodSpecialsRepository = lazyDailyFoodSpecialsRepository;
            this.lazyRestaurantRepository = lazyRestaurantRepository;
            this.lazyYelpAPIService = lazyYelpAPIService;
        }

        #endregion

        #region Public Methods
        ///<inheritdoc>
        //public IQueryable<RestaurantViewModel> MakeIndexViewModel()
        //{
        //    return lazyRestaurantRepository.Value.GetAll()
        //        .Select(x => MakeRestaurantViewModelFromRestaurant(x));
        //}

        public void AddRestaurant(string id)
        {
            var restaurant = new Restaurant();
            restaurant.RestaurantId = id;
            lazyRestaurantRepository.Value.Insert(restaurant);
        }

        public IEnumerable<Business> GetRestaurantsByCoordinates(double latitude, double longitude)
        {
            //Get restaurants near coordinates, then populate food specials.
            var restaurants = lazyYelpAPIService.Value.SearchRestaurantsByCoordinates(latitude, longitude);
                //.Select(x => x.DailyFoodSpecials = lazyDailyFoodSpecialsRepository.Value.GetDailyFoodSpecialsForRestaurant(x.id));

            return restaurants;
        }

        /////<inheritdoc>
        //public void CreateRestaurant(RestaurantViewModel viewModel)
        //{
        //    var restaurant = MakeRestaurantFromViewModel(viewModel);
        //    lazyRestaurantRepository.Value.Insert(restaurant);
        //}

        /////<inheritdoc>
        //public Restaurant GetRestaurantById(int id)
        //{
        //    return lazyRestaurantRepository.Value.GetByID(id);
        //}

        /////<inheritdoc>
        //public RestaurantViewModel MakeUpdateRestaurantViewModel(int id)
        //{
        //    var restaurant = lazyRestaurantRepository.Value.GetByID(id);
        //    return MakeRestaurantViewModelFromRestaurant(restaurant);
        //}

        /////<inheritdoc>
        //public void UpdateRestaurant(RestaurantViewModel viewModel)
        //{
        //    var restaurant = MakeRestaurantFromViewModel(viewModel);
        //    lazyRestaurantRepository.Value.Update(restaurant);
        //}

        ///<inheritdoc>
        public DeleteModalViewModel MakeDeleteRestaurantModalViewModel(int id)
        {
            return new DeleteModalViewModel
            {
                BackgroundColor = "bg-danger",
                //Title = Utils.GetStringValue("DeleteText") + " \"" + lazyRestaurantRepository.Value.GetByID(id).RestaurantName + "\"",
                Body = Utils.GetStringValue("DeleteRestaurantText"),
                ButtonText = Utils.GetStringValue("DeleteText"),
                DeleteUrl = "/Restaurants/DeleteConfirmed?entityId=" + id
            };
        }

        ///<inheritdoc>
        public void DeleteRestaurant(int id)
        {
            lazyRestaurantRepository.Value.Delete(id);
        }
        
        ///<inheritdoc>
        public IEnumerable<RestaurantDTO> GetTop20Restaurants()
        {
            return lazyRestaurantRepository.Value.GetAll().Take(20).Select(x => MakeRestaurantDTOFromRestaurant(x));
        }

        ///<inheritdoc>
        public IEnumerable<RestaurantDTO> GetTop20ClosestRestaurants(double latitude, double longitude)
        {
            var restuarants = lazyRestaurantRepository.Value.GetAll();

            //Order by distance
            //var restaurantsByDistance = restuarants.OrderBy(x => new GeoCoordinate(x.Latitude, x.Longitude).GetDistanceTo(new GeoCoordinate(latitude, longitude)));
                
            //Return top 20
            return restuarants.Select(y => MakeRestaurantDTOFromRestaurant(y));
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Make the restaurant from the view model
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns>Restaurant</returns>
        private Restaurant MakeRestaurantFromViewModel(RestaurantViewModel viewModel)
        {
            var restaurant = new Restaurant
            {
                RestaurantId = viewModel.RestaurantId,
                //RestaurantName = viewModel.RestaurantName,
                //Address1 = viewModel.Address1,
                //Address2 = viewModel.Address2,
                //City = viewModel.City,
                //State = viewModel.State,
                //Zip = viewModel.Zip,
                //OpeningTime = Utils.ConvertStringToTimespan(viewModel.OpeningTime),
                //ClosingTime = Utils.ConvertStringToTimespan(viewModel.ClosingTime),

            };

            //Set latitude and longitude
            var mapPoint = Utils.GetCoordinatesForAddress(GetRestaurantFullAddress(restaurant));
            //restaurant.Latitude = mapPoint.Latitude;
            //restaurant.Longitude = mapPoint.Longitude;

            return restaurant;

        }

        /// <summary>
        /// Makes the view model from the restaurant
        /// </summary>
        /// <param name="restaurant">The restaurant</param>
        /// <returns>View Model</returns>
        private RestaurantViewModel MakeRestaurantViewModelFromRestaurant(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                RestaurantId = restaurant.RestaurantId,
                //RestaurantName = restaurant.RestaurantName,
                //City = restaurant.City,
                //State = restaurant.State,
                //Zip = restaurant.Zip,
                //OpeningTime = Utils.ConvertTimespanToString(restaurant.OpeningTime),
                //ClosingTime = Utils.ConvertTimespanToString(restaurant.ClosingTime),
            };
        }

        /// <summary>
        /// Make the Restaurant DTO from a restaurant object
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns>A new RestaurantDTO</returns>
        private RestaurantDTO MakeRestaurantDTOFromRestaurant(Restaurant restaurant)
        {
            var restaurantDTO = new RestaurantDTO
            {
                //RestaurantName = restaurant.RestaurantName,
                //FullAddress = GetRestaurantFullAddress(restaurant),
                //MapPoint = new MapPoint
                //{
                //    Latitude = restaurant.Latitude,
                //    Longitude = restaurant.Longitude
                //}
            };
            //if(restaurant.RestaurantHour != null) {
            //    restaurantDTO.RestaurantHour = new RestaurantHour
            //    {
            //        Sunday_Open_Time = restaurant.RestaurantHour.Sunday_Open_Time,
            //        Sunday_Close_Time = restaurant.RestaurantHour.Sunday_Close_Time,
            //        Monday_Open_Time = restaurant.RestaurantHour.Monday_Open_Time,
            //        Monday_Close_Time = restaurant.RestaurantHour.Monday_Close_Time,
            //        Tuesday_Open_Time = restaurant.RestaurantHour.Tuesday_Open_Time,
            //        Tuesday_Close_Time = restaurant.RestaurantHour.Tuesday_Close_Time,
            //        Wednesday_Open_Time = restaurant.RestaurantHour.Wednesday_Open_Time,
            //        Wednesday_Close_Time = restaurant.RestaurantHour.Wednesday_Close_Time,
            //        Thursday_Open_Time = restaurant.RestaurantHour.Thursday_Open_Time,
            //        Thursday_Close_Time = restaurant.RestaurantHour.Thursday_Close_Time,
            //        Friday_Open_Time = restaurant.RestaurantHour.Friday_Open_Time,
            //        Friday_Close_Time = restaurant.RestaurantHour.Friday_Close_Time,
            //        Saturday_Open_Time = restaurant.RestaurantHour.Saturday_Open_Time,
            //        Saturday_Close_Time = restaurant.RestaurantHour.Saturday_Close_Time
            //    };              
            //};
            return restaurantDTO;
        }

        /// <summary>
        /// Formats the restaurants full address into a single string
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        private string GetRestaurantFullAddress(Restaurant restaurant)
        {
            return string.Empty;
            ////Dont include address 2 if it is blank
            //var address = string.IsNullOrEmpty(restaurant.Address2) ? restaurant.Address1 : restaurant.Address1 + " " + restaurant.Address2;

            ////Get the latitude and longitude
            //return address + " " + restaurant.City + ", " + restaurant.State + " " + restaurant.Zip;
        }

        public IEnumerable<AddRestaurantViewModel> SearchRestaurants(string term, string location)
        {
            var viewModels = lazyYelpAPIService.Value.SearchRestaurantsByLocationAndTerm(location, term)
                .Select(x => new AddRestaurantViewModel(x))
                .ToList();

            var storedYelpIds = lazyRestaurantRepository.Value.GetAll().Select(x => x.RestaurantId);

            viewModels.ForEach(x => 
                x.NotAdded = storedYelpIds.Contains(x.YelpId) == false);
            return viewModels;
        }

        #endregion
    }
}