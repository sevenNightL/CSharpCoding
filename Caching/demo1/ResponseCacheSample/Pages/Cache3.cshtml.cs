using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
    #region snippet
    [ResponseCache(Duration = 1000000000, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class Cache3Model : PageModel
    {
        #endregion

    
        public void OnGet()
        {
           // Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] = "public,max-age=600";
        }
    }
}
