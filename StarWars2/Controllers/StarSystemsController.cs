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
    public class StarSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StarSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarSystem.ToListAsync());
        }

        // GET: StarSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starSystem = await _context.StarSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starSystem == null)
            {
                return NotFound();
            }

            return View(starSystem);
        }

        // GET: StarSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,XCoordinate,YCoordinate")] StarSystem starSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starSystem);
        }

        // GET: StarSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starSystem = await _context.StarSystem.FindAsync(id);
            if (starSystem == null)
            {
                return NotFound();
            }
            return View(starSystem);
        }

        // POST: StarSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,XCoordinate,YCoordinate")] StarSystem starSystem)
        {
            if (id != starSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarSystemExists(starSystem.Id))
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
            return View(starSystem);
        }

        // GET: StarSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starSystem = await _context.StarSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starSystem == null)
            {
                return NotFound();
            }

            return View(starSystem);
        }

        // POST: StarSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starSystem = await _context.StarSystem.FindAsync(id);
            _context.StarSystem.Remove(starSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarSystemExists(int id)
        {
            return _context.StarSystem.Any(e => e.Id == id);
        }
    }
}
