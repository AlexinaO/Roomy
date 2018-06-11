using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Roomy.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            //throw new Exception();
            return View();
        }

        [Route("/error/{code?}")]
        public IActionResult Error(string code)
        {
            return View();
        }
    }
}