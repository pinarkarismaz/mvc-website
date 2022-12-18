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
    public class BurcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BurcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Burcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Burc.ToListAsync());
        }

        // GET: Burcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burc = await _context.Burc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burc == null)
            {
                return NotFound();
            }

            return View(burc);
        }

        // GET: Burcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,burc_adi,burc_tarihi,burc_resim,grup_Id")] Burc burc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burc);
        }

        // GET: Burcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burc = await _context.Burc.FindAsync(id);
            if (burc == null)
            {
                return NotFound();
            }
            return View(burc);
        }

        // POST: Burcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,burc_adi,burc_tarihi,burc_resim,grup_Id")] Burc burc)
        {
            if (id != burc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurcExists(burc.Id))
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
            return View(burc);
        }

        // GET: Burcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burc = await _context.Burc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burc == null)
            {
                return NotFound();
            }

            return View(burc);
        }

        // POST: Burcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burc = await _context.Burc.FindAsync(id);
            _context.Burc.Remove(burc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurcExists(int id)
        {
            return _context.Burc.Any(e => e.Id == id);
        }
    }
}
