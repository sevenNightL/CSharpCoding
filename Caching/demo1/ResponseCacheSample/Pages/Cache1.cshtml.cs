using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
   [ResponseCache(VaryByHeader ="User-Agent",Duration =30)]
    public class Cache1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
