using FoodSpecialsUI.Models;
using FoodSpecialsUI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodSpecialsUI.Services
{
    public interface IFoodSpecialService
    {

        #region UI Code

        ///// <summary>
        ///// Makes the view model for the index view
        ///// </summary>
        ///// <returns>daily food special view model</returns>
        //IQueryable<FoodSpecial> MakeIndexViewModel();

        ///// <summary>
        ///// Insert a new food special
        ///// </summary>
        ///// <param name="foodSpecialViewModel">daily food special view model</param>
        //void InsertDailyFoodSpecial(FoodSpecialViewModel foodSpecialViewModel);

        ///// <summary>
        ///// Make the view model for updating a daily food special
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //FoodSpecialViewModel MakeUpdateDailyFoodSpecialViewModel(int id);

        ///// <summary>
        ///// Update a daily food special
        ///// </summary>
        ///// <param name="foodSpecialViewModel">daily food special to update</param>
        //void UpdateDailyFoodSpecial(FoodSpecialViewModel foodSpecialViewModel);

        ///// <summary>
        ///// Make the view model for deleting a daily food special
        ///// </summary>
        ///// <param name="id">id of daily food special</param>
        ///// <returns></returns>
        //DeleteModalViewModel MakeDeleteDailyFoodSpecialModalViewModel(int id);

        ///// <summary>
        ///// Delete a daily food special
        ///// </summary>
        ///// <param name="id">id of daily food special to delete</param>
        //void DeleteDailyFoodSpecial(int id);

        /////// <summary>
        /////// Gets a list of restaurants with matching names
        /////// </summary>
        /////// <param name="partialName">partial name the user entered</param>
        /////// <returns>Json result of restaurants</returns>
        ////JsonResult GetRestaurantNamesJson(string partialName);

        ///// <summary>
        ///// Gets the daily food specials for a restaurant.
        ///// </summary>
        ///// <param name="id">Restaurant id</param>
        ///// <returns>List of daily food specials</returns>
        //IQueryable<FoodSpecial> GetDailyFoodSpecialsForRestaurant(int id);

        #endregion
        
        /// <summary>
        /// Inserts a food special
        /// </summary>
        /// <param name="foodSpecial">The food special to add</param>
        void Insert(FoodSpecial foodSpecial);

        /// <summary>
        /// Deletes a food special
        /// </summary>
        /// <param name="id">Id of the food special</param>
        void Delete(int id);

        /// <summary>
        /// Gets the food specials for a restaurant
        /// </summary>
        /// <param name="restaurantId">Id of restaurant</param>
        /// <returns>List of food Specials</returns>
        IEnumerable<FoodSpecial> GetFoodSpecialsForRestaurant(string restaurantId);

        /// <summary>
        /// Updates the food special
        /// </summary>
        /// <param name="foodSpecial">The food special object</param>
        void Update(FoodSpecial foodSpecial);
    }
}
