using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace CoreWebApp
{
    public class RestaurantDetailsModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurant RestaurantData;

        public RestaurantDetailsModel(IRestaurant restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetRestaurantById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound", new { ResourceName = "RestaurantDetails"});
            }

            return Page();
            //System.Diagnostics.Debug.WriteLine(Restaurant); (To write a msg on Output View)
        }
    }
}