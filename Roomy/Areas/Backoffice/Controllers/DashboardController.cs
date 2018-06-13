using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomy.Filters;

namespace Roomy.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    [AuthenticationFilter(role: "admin")]    
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}