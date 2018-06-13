using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomy.Data;
using Roomy.Models;

namespace Roomy.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(RoomyDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                await db.Users.AddAsync(model);
                await db.SaveChangesAsync();
                DisplayMessage("Utilisateur enregistré", MessageType.OK);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}