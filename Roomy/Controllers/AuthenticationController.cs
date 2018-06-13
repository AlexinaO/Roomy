using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Roomy.Data;
using Roomy.Filters;
using Roomy.Models;

namespace Roomy.Controllers
{
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(RoomyDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.SingleOrDefaultAsync(x => x.Mail == model.Mail && x.Password == model.Password);
                if(user != null)
                {
                    HttpContext.Session.SetString("USER_BO", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "Dashboard", new { area = "Backoffice" });
                }
                DisplayMessage("Login/mot de passe incorrect.", MessageType.ERROR);
            }
            return View();
        }

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("USER_BO");
            HttpContext.Session.Clear();
            DisplayMessage("Vous êtes déconnecté", MessageType.OK);
            return RedirectToAction("index", "home");
        }
    }
}