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
    public class StarTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StarTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarType.ToListAsync());
        }

        // GET: StarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _context.StarType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starType == null)
            {
                return NotFound();
            }

            return View(starType);
        }

        // GET: StarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StarType starType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starType);
        }

        // GET: StarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _context.StarType.FindAsync(id);
            if (starType == null)
            {
                return NotFound();
            }
            return View(starType);
        }

        // POST: StarTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StarType starType)
        {
            if (id != starType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarTypeExists(starType.Id))
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
            return View(starType);
        }

        // GET: StarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _context.StarType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starType == null)
            {
                return NotFound();
            }

            return View(starType);
        }

        // POST: StarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starType = await _context.StarType.FindAsync(id);
            _context.StarType.Remove(starType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarTypeExists(int id)
        {
            return _context.StarType.Any(e => e.Id == id);
        }
    }
}
