using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomy.Data;
using Roomy.Models;

namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
        private RoomyDbContext db;
        public UsersController(RoomyDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                await db.Users.AddAsync(model);
                await db.SaveChangesAsync();
            }
            return View();
        }
    }
}