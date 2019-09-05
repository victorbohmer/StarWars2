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
    public class PlanetTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanetTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlanetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanetType.ToListAsync());
        }

        // GET: PlanetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetType = await _context.PlanetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planetType == null)
            {
                return NotFound();
            }

            return View(planetType);
        }

        // GET: PlanetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PlanetType planetType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planetType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planetType);
        }

        // GET: PlanetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetType = await _context.PlanetType.FindAsync(id);
            if (planetType == null)
            {
                return NotFound();
            }
            return View(planetType);
        }

        // POST: PlanetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PlanetType planetType)
        {
            if (id != planetType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetTypeExists(planetType.Id))
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
            return View(planetType);
        }

        // GET: PlanetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetType = await _context.PlanetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planetType == null)
            {
                return NotFound();
            }

            return View(planetType);
        }

        // POST: PlanetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planetType = await _context.PlanetType.FindAsync(id);
            _context.PlanetType.Remove(planetType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetTypeExists(int id)
        {
            return _context.PlanetType.Any(e => e.Id == id);
        }
    }
}
