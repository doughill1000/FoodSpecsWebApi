using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSpecialsUI.ViewModels
{
    public class DeleteModalViewModel : CommonModalViewModel
    {
        /// <summary>
        /// Id of the entity being deleted
        /// </summary>
        public string DeleteUrl { get; set; }
    }
}