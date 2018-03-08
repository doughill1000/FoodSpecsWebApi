using FoodSpecialsUI.Models;
using System.Linq;

namespace FoodSpecialsUI.Repository
{
    public class RestaurantRepository : GenericRepository<HillBrosInc_FoodSpecialsEntities, Restaurant>, IRestaurantRepository
    {
        //<inheritdoc>
        public IQueryable<Restaurant> GetRestaurantsByPartialName(string partialName)
        {
            return GetAll();
                //.Where(x => x.RestaurantName.Contains(partialName));
        }

        //<inheritdoc>
        public IQueryable<Restaurant> GetRestaurantByYelpId(string yelpId)
        {
            return GetAll().Where(x => x.RestaurantId == yelpId);
        }


    }
}