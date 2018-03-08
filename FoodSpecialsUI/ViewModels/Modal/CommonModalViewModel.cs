using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSpecialsUI.ViewModels
{
    public class CommonModalViewModel
    {
        /// <summary>
        /// Modal title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Modal body text
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Modal button text
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// Modal background color
        /// </summary>
        public string BackgroundColor { get; set; }
    }
}