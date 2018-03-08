using FoodSpecialsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodSpecialsUI.Repository
{
    /// <summary>
    /// Repository for managing Food Specials.
    /// </summary>
    public class FoodSpecialRepository : GenericRepository<HillBrosInc_FoodSpecialsEntities, FoodSpecial>, IFoodSpecialRepository
    {
        //<inheritdoc>
        public IQueryable<FoodSpecial> GetFoodSpecialsForRestaurant(string id)
        {
            return Context.FoodSpecials.Where(x => x.RestaurantId == id);
        }

        //<inheritdoc>
        public override void Insert(FoodSpecial entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Active = true;
            base.Insert(entity);
        }

        //<inheritdoc>
        public override void Update(FoodSpecial entity)
        {
            entity.CreateDate = DateTime.Now;
            base.Update(entity);
        }

        public IQueryable<FoodSpecial> GetAll(IEnumerable<string> restuarantIds)
        {
            return base.GetAll().Where(x => restuarantIds.Contains(x.RestaurantId));            
        }
    }
}