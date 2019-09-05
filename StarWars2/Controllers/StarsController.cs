using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarWars2.Data;
using StarWars2.Models;

namespace StarWars2.Controllers
{
    public class StarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Star.Include(s => s.StarSystem).Include(s => s.StarType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Star
                .Include(s => s.StarSystem)
                .Include(s => s.StarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // GET: Stars/Create
        public IActionResult Create()
        {
            ViewData["StarSystem"] = new SelectList(_context.StarSystem, "Id", "Name");
            ViewData["StarType"] = new SelectList(_context.StarType, "Id", "Name");
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StarSystemId,StarTypeId,Name")] Star star)
        {
            if (ModelState.IsValid)
            {
                _context.Add(star);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StarSystemId"] = new SelectList(_context.StarSystem, "Id", "Id", star.StarSystemId);
            ViewData["StarTypeId"] = new SelectList(_context.StarType, "Id", "Id", star.StarTypeId);
            return View(star);
        }

        // GET: Stars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Star.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }
            ViewData["StarSystem"] = new SelectList(_context.StarSystem, "Id", "Name", star.StarSystemId);
            ViewData["StarType"] = new SelectList(_context.StarType, "Id", "Name", star.StarTypeId);
            return View(star);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StarSystemId,StarTypeId,Name")] Star star)
        {
            if (id != star.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(star);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarExists(star.Id))
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
            ViewData["StarSystemId"] = new SelectList(_context.StarSystem, "Id", "Id", star.StarSystemId);
            ViewData["StarTypeId"] = new SelectList(_context.StarType, "Id", "Id", star.StarTypeId);
            return View(star);
        }

        // GET: Stars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Star
                .Include(s => s.StarSystem)
                .Include(s => s.StarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var star = await _context.Star.FindAsync(id);
            _context.Star.Remove(star);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarExists(int id)
        {
            return _context.Star.Any(e => e.Id == id);
        }
    }
}
