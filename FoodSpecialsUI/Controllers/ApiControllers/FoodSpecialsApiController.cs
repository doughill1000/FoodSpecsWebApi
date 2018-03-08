using FoodSpecialsUI.Constants;
using FoodSpecialsUI.Models;
using FoodSpecialsUI.Services;
using System;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace FoodSpecialsUI.Controllers
{
    [Authorize(Roles = AuthConstants.Admin + "," + AuthConstants.User)]
    public class FoodSpecialsApiController : ApiController
    {
        private Lazy<IFoodSpecialService> lazyFoodSpecialsService;
        private Lazy<IAuthService> lazyAuthService;

        public FoodSpecialsApiController(Lazy<IFoodSpecialService> lazyFoodSpecialsService, Lazy<IAuthService> lazyAuthService)
        {
            this.lazyFoodSpecialsService = lazyFoodSpecialsService;
            this.lazyAuthService = lazyAuthService;
        }

        /// <summary>
        /// Get a food special by it's id
        /// </summary>
        /// <param name="id">Id of food special</param>
        /// <returns>Food special object</returns>
        [HttpGet]
        public FoodSpecial GetFoodSpecial(int id)
        {
            return new FoodSpecial(); //TODO
        }

        /// <summary>
        /// Adds a food special to the database
        /// </summary>
        /// <param name="foodSpecial"></param>
        [HttpPost]
        public IHttpActionResult Post([FromBody] FoodSpecial foodSpecial)
        {
            //Get current users id
            foodSpecial.OwnerId = RequestContext.Principal.Identity.GetUserId();

            lazyFoodSpecialsService.Value.Insert(foodSpecial);               

            return Ok();
        }

        /// <summary>
        /// Used for updating a food special in the db
        /// </summary>
        /// <param name="foodSpecial">The food special object</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put([FromBody] FoodSpecial foodSpecial)
        {
            lazyFoodSpecialsService.Value.Update(foodSpecial);

            return Ok();
        }

        /// <summary>
        /// Deletes a food special in the db.
        /// </summary>
        /// <param name="id">Id of the food special to delete</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            lazyFoodSpecialsService.Value.Delete(id);

            return Ok();
        }

        /// <summary>
        /// Gets the food specials for a restaurant
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant to get specials for.</param>
        /// <returns>List of food specials</returns>
        [HttpGet]
        public List<FoodSpecial> GetFoodSpecialsForRestaurant(string restaurantId)
        {
            return lazyFoodSpecialsService.Value.GetFoodSpecialsForRestaurant(restaurantId).ToList();
        }
    }
}
