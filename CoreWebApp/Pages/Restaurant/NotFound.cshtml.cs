using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApp
{
    public class NotFoundModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ResourceName { get; set; }

        public void OnGet()
        {

        }
    }
}