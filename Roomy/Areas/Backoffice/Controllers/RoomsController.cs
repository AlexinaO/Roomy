using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roomy.Data;
using Roomy.Filters;
using Roomy.Models;

namespace Roomy.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    [AuthenticationFilter]
    public class RoomsController : Controller
    {
        private readonly RoomyDbContext _context;

        public RoomsController(RoomyDbContext context)
        {
            _context = context;
        }

        // GET: Backoffice/Rooms
        public async Task<IActionResult> Index()
        {
            var roomyDbContext = _context.Rooms.Include(r => r.User).Where(x => !x.Deleted);
            return View(await roomyDbContext.ToListAsync());
        }

        // GET: Backoffice/Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Backoffice/Rooms/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Mail");
            return View();
        }

        // POST: Backoffice/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Label,Capacity,Price,Description,CreateDate,UserID,ID,Deleted")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Lastname", room.UserID);
            return View(room);
        }

        // GET: Backoffice/Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.Include(x => x.Files).SingleOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Lastname", room.UserID);
            return View(room);
        }

        // POST: Backoffice/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Label,Capacity,Price,Description,CreateDate,UserID,ID,Deleted")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Lastname", room.UserID);
            return View(room);
        }

        // GET: Backoffice/Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Backoffice/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(m => m.ID == id);
            //_context.Rooms.Remove(room);
            room.Deleted = true;
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.ID == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(int id, IFormFile upload)
        {
            if(upload.Length > 0)
            {
                var file = new File
                {
                    ContentType = upload.ContentType,
                    Name = System.IO.Path.GetFileName(upload.FileName),
                    RoomID = id
                };

                using( var reader = new System.IO.BinaryReader(upload.OpenReadStream()))
                {
                    file.Content = reader.ReadBytes(Convert.ToInt32(upload.Length));
                }

                _context.Files.Add(file);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { id });

        }

    }
}
