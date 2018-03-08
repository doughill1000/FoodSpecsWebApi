using YelpSharper.Models;

namespace FoodSpecialsUI.ViewModels
{
    public class AddRestaurantViewModel
    {
        public AddRestaurantViewModel(Business Business)
        {
            this.YelpId = Business.Id;
            Name = Business.Name;
            DisplayAddress = Business.Location.Address1;

        }

        /// <summary>
        /// The restaurant id that is kept apart from Yelp data.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// The yelp id.
        /// </summary>
        public string YelpId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the restaurants display address.
        /// </summary>
        public string DisplayAddress { get; set; }

        /// <summary>
        /// If the yelp restaurant has been added to the database.
        /// </summary>
        public bool NotAdded { get; set; }
    }
}