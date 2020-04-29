using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace CoreWebApp
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurant restaurantData;

        // Output Model: these are to populate the information in HTML page
        public string Message;
        public IEnumerable<Restaurant> Restaurants;
        public IEnumerable<Restaurant> RestaurantsByName { get; private set; }

        // Input Model: Input parameter received to this page
        [BindProperty(SupportsGet =true)]      // Special attribute which can make this property as Input + Output model
        public string SearchRest { get; set; }  // But this binds property to POST operation by default

        // Only INPUT Model:
        // Then pass parameter in OnGet method (No need to declare it as property)

        public ListModel(IConfiguration config, IRestaurant restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        // GET: /Restaurant/List?QueryString...
        // public void OnGet(string searchRest)
        public void OnGet()
        {
            // One more way to access form data can be using HttpContext
            // To find something in request particularly- Form inputs, QueryString parameter, HTTP header

            // One we used is Model Binding (Note: <input>'s name attribute must match the parameter name
            // TAKE CARE of case when there is no query string then this parameter can raise an exception

            // SearchRest = searchRest;     // First way to bind input property instead of using BindProperty attribute

            Message = config["Message"];
            Restaurants = restaurantData.GetAll();

            RestaurantsByName = restaurantData.GetRestaurantsByName(SearchRest);
        }
    }
}