using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace CoreWebApp
{
    public class EditRestaurantModel : PageModel
    {
        [BindProperty]  // As its a Input Model for Post request (after submitting changes)
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        private readonly IRestaurant RestaurantData;
        private readonly IHtmlHelper htmlHelper;

        public EditRestaurantModel(IRestaurant restaurantData,
                                    IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = RestaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound", new { ResourceName = "EditRestaurant" });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Because ASP.Net core is stateless so OnPost() request Cuisines Enum will be lost
            // as populated by OnGet()
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (ModelState.IsValid) // Validating Data Annotations using IsValid Property
            {                       // if any validation error occurs then it is saved in
                                    // ModelState["Location"].Errors collection (for Restaurant.Location field only)
                RestaurantData.Update(Restaurant);  // Yha pr restaurant avail kese hua
                RestaurantData.commit();
                // As post must redirect to some Get req page so the changes might not 
                // get submitted again if user refreshes the page
                return RedirectToPage("./RestaurantDetails", new { RestaurantId = Restaurant.id });
            }

            return Page();
        }
    }
}