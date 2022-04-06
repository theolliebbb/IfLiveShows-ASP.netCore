using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFLiveShows.Data;
using IFLiveShows.Models;
using Microsoft.AspNetCore.Authorization;

namespace IFLiveShows.Controllers
{
    public class LiveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LiveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Live
        public async Task<IActionResult> Index()
        {
            return View(await _context.Live.ToListAsync());
        }

        // GET: Live/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: Live/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Live/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Venue,TicketUrl,ImageUrl,MapsUrl")] Live live)
        {
            if (ModelState.IsValid)
            {
                _context.Add(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(live);
        }

        // GET: Live/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live.FindAsync(id);
            if (live == null)
            {
                return NotFound();
            }
            return View(live);
        }

        // POST: Live/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Venue,TicketUrl,ImageUrl,MapsUrl")] Live live)
        {
            if (id != live.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(live);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiveExists(live.Id))
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
            return View(live);
        }

        // GET: Live/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // POST: Live/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var live = await _context.Live.FindAsync(id);
            _context.Live.Remove(live);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiveExists(int id)
        {
            return _context.Live.Any(e => e.Id == id);
        }
    }
}
