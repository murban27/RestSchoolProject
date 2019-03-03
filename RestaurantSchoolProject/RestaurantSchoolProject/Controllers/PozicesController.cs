using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSchoolProject.Models;

namespace RestaurantSchoolProject.Controllers
{
    public class PozicesController : Controller
    {
        private readonly RestaurantContext _context;

        public PozicesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Pozices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pozice.ToListAsync());
        }

        // GET: Pozices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozice = await _context.Pozice
                .FirstOrDefaultAsync(m => m.PoziceId == id);
            if (pozice == null)
            {
                return NotFound();
            }

            return View(pozice);
        }

        // GET: Pozices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoziceId,PopisPozice")] Pozice pozice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozice);
        }

        // GET: Pozices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozice = await _context.Pozice.FindAsync(id);
            if (pozice == null)
            {
                return NotFound();
            }
            return View(pozice);
        }

        // POST: Pozices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoziceId,PopisPozice")] Pozice pozice)
        {
            if (id != pozice.PoziceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoziceExists(pozice.PoziceId))
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
            return View(pozice);
        }

        // GET: Pozices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozice = await _context.Pozice
                .FirstOrDefaultAsync(m => m.PoziceId == id);
            if (pozice == null)
            {
                return NotFound();
            }

            return View(pozice);
        }

        // POST: Pozices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozice = await _context.Pozice.FindAsync(id);
            _context.Pozice.Remove(pozice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoziceExists(int id)
        {
            return _context.Pozice.Any(e => e.PoziceId == id);
        }
    }
}
