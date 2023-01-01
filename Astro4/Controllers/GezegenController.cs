using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Astro4.Data;
using Astro4.Models;

namespace Astro4.Controllers
{
    public class GezegenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GezegenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gezegen
        public async Task<IActionResult> Index()
        {
              return View(await _context.Gezegen.ToListAsync());
        }

        // GET: Gezegen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gezegen == null)
            {
                return NotFound();
            }

            var gezegen = await _context.Gezegen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gezegen == null)
            {
                return NotFound();
            }

            return View(gezegen);
        }

        // GET: Gezegen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gezegen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,tarih_ad,gun_burc")] Gezegen gezegen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gezegen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gezegen);
        }

        // GET: Gezegen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gezegen == null)
            {
                return NotFound();
            }

            var gezegen = await _context.Gezegen.FindAsync(id);
            if (gezegen == null)
            {
                return NotFound();
            }
            return View(gezegen);
        }

        // POST: Gezegen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,tarih_ad,gun_burc")] Gezegen gezegen)
        {
            if (id != gezegen.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gezegen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GezegenExists(gezegen.ID))
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
            return View(gezegen);
        }

        // GET: Gezegen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gezegen == null)
            {
                return NotFound();
            }

            var gezegen = await _context.Gezegen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gezegen == null)
            {
                return NotFound();
            }

            return View(gezegen);
        }

        // POST: Gezegen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gezegen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gezegen'  is null.");
            }
            var gezegen = await _context.Gezegen.FindAsync(id);
            if (gezegen != null)
            {
                _context.Gezegen.Remove(gezegen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GezegenExists(int id)
        {
          return _context.Gezegen.Any(e => e.ID == id);
        }
    }
}
