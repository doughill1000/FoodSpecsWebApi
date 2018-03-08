using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSpecialsUI.ViewModels
{
    public class FoodSpecialViewModel
    {
        public int SpecialId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool? SundayActive { get; set; }
        public bool? MondayActive { get; set; }
        public bool? TuesdayActive { get; set; }
        public bool? WednesdayActive { get; set; }
        public bool? ThursdayActive { get; set; }
        public bool? FridayActive { get; set; }
        public bool? SaturdayActive { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set;}
    }
}