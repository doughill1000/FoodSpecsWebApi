using FoodSpecialsUI.Models;
using System.Collections.Generic;
using YelpSharper.Models;

namespace FoodSpecialsUI.DTOs
{
    public class RestaurantDTO : Business
    {
        /// <summary>
        /// 
        /// </summary>
        public List<FoodSpecial> FoodSpecials {get;set;}
    }
}