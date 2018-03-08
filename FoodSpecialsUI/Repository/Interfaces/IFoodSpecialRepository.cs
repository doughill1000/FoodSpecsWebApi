using FoodSpecialsUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FoodSpecialsUI.Repository
{
    [ContractClass(typeof(IFoodSpecialRepositoryContract))]
    public interface IFoodSpecialRepository : IGenericRepository<FoodSpecial>
    {
        /// <summary>
        /// Gets all of the daily food specials for a restaurant.
        /// </summary>
        /// <param name="id">Id of restaurant</param>
        /// <returns>Iqueryable of daily food specials</returns>
        IQueryable<FoodSpecial> GetFoodSpecialsForRestaurant(string id);

        /// <summary>
        /// Inserts the food special entity into the db.
        /// </summary>
        /// <param name="entity">The food special.</param>
        new void Insert(FoodSpecial entity);

        /// <summary>
        /// Gets all food specials by resturant ids
        /// </summary>
        /// <param name="restuarantIds"></param>
        /// <returns>Food specials</returns>
        IQueryable<FoodSpecial> GetAll(IEnumerable<string> restuarantIds);
    }

    [ContractClassFor(typeof(IFoodSpecialRepository))]
    abstract class IFoodSpecialRepositoryContract : IFoodSpecialRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FoodSpecial> GetAll()
        {
            throw new NotImplementedException();
        }

        public FoodSpecial GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(FoodSpecial entity)
        {
            throw new NotImplementedException();
        }

        public void Update(FoodSpecial entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FoodSpecial> GetFoodSpecialsForRestaurant(string id)
        {
            Contract.Requires(!string.IsNullOrEmpty(id));
            throw new NotImplementedException();
        }

        public IQueryable<FoodSpecial> GetAll(IEnumerable<string> restuarantIds)
        {
            Contract.Requires(restuarantIds != null);
            throw new NotImplementedException();
        }
    }

}