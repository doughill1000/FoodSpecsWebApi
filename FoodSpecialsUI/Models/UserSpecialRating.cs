//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodSpecialsUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSpecialRating
    {
        public int SpecialID { get; set; }
        public string UserId { get; set; }
        public Nullable<int> Rating { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual FoodSpecial FoodSpecial { get; set; }
    }
}