using FoodSpecialsUI.Models;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;
using System;

namespace FoodSpecialsUI.Repository
{
    [ContractClass(typeof(IRestaurantRepositoryContract))]
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        /// <summary>
        /// Gets restaurants by partial name
        /// </summary>
        /// <param name="">partial name entered by user</param>
        /// <returns>List of restaurants</returns>
        IQueryable<Restaurant> GetRestaurantsByPartialName(string partialName);

        /// <summary>
        /// Gets the restaurant by YelpId.
        /// </summary>
        /// <param name="yelpId"></param>
        /// <returns></returns>
        IQueryable<Restaurant> GetRestaurantByYelpId(string yelpId);
    }

    [ContractClassFor(typeof(IDailyFoodSpecialRepository))]
    abstract class IRestaurantRepositoryContract : IRestaurantRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Restaurant> GetRestaurantsByPartialName(string partialName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Restaurant> GetRestaurantByYelpId(string yelpId)
        {
            Contract.Requires(yelpId != null);
            throw new NotImplementedException();
        }
    }
}
