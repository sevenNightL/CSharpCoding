using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
    #region snippet
    [ResponseCache(CacheProfileName = "Default30",Duration =25)]
    public class Cache4Model : PageModel
    {
        #endregion
        public void OnGet()
        {
        }
    }
}
