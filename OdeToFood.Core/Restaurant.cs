using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int id { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public Boolean PureVeg { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
