using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using astro1.Data;
using astro1.Models;

namespace astro1.Controllers
{
    public class GrupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grup.ToListAsync());
        }

        // GET: Grups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

        // GET: Grups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,grup_adi")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grup);
        }

        // GET: Grups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grup.FindAsync(id);
            if (grup == null)
            {
                return NotFound();
            }
            return View(grup);
        }

        // POST: Grups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,grup_adi")] Grup grup)
        {
            if (id != grup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupExists(grup.Id))
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
            return View(grup);
        }

        // GET: Grups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

        // POST: Grups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grup = await _context.Grup.FindAsync(id);
            _context.Grup.Remove(grup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupExists(int id)
        {
            return _context.Grup.Any(e => e.Id == id);
        }
    }
}
