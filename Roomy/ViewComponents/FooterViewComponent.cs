using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private RoomyDbContext db;

        public FooterViewComponent(RoomyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_footer", await db.Rooms.Where(x => !x.Deleted).ToListAsync());
        }
    }
}
