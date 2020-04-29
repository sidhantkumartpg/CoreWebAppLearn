using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApp
{
    public class ErrorAddRestModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public ModelStateDictionary modelStates { get; set; }
        public void OnGet()
        {

        }
    }
}