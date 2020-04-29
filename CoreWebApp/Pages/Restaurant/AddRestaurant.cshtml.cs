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
    public class AddRestaurantModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IRestaurant RestaurantData { get; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public AddRestaurantModel(IRestaurant restaurantData,
                                IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            //Restaurant = new Restaurant();
        }

        public IActionResult OnPost()
        {
            System.Diagnostics.Debug.WriteLine("---------------OnPost-----------------");
            System.Diagnostics.Debug.WriteLine(Restaurant == null);

            if (ModelState.IsValid) // Validating Data Annotations(of Model) using IsValid Property
            {                       // if any validation error occurs then it is saved in
                                    // ModelState["Location"].Errors collection (for Restaurant.Location field only)
                RestaurantData.Create(Restaurant);  // Yha pr restaurant avail kese hua
                RestaurantData.commit();
                // As post must redirect to some Get req page so the changes might not 
                // get submitted again if user refreshes the page
                return RedirectToPage("./List");
            }

            System.Diagnostics.Debug.WriteLine("-----------------------Debug-----------------------------");
            System.Diagnostics.Debug.WriteLine(ModelState["PureVeg"].Errors[0]);

            return RedirectToPage("./ErrorAddRest", new { modelStates = ModelState.Values});
        }
    }
}