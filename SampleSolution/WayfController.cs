using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WayfJwtConector;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleSolution
{
    public class WayfController : Controller
    {
        private readonly WayfClient wayfClient; 
        public WayfController(WayfClient wayfClient)
        {
            this.wayfClient = wayfClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = await wayfClient.RedirectUrl();
            return Redirect(url);
        }

        [HttpPost("/wayf/ls")]
        public async Task<IActionResult> ValidateWayfLogin()
        {
            var data = await wayfClient.ValidateAsync(Request.Body);
            return Ok(data);
        }
    }
}
