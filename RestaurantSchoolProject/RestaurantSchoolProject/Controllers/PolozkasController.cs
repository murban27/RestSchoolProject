using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSchoolProject.Models;

namespace RestaurantSchoolProject.Controllers
{
    public class PolozkasController : Controller
    {
        private readonly RestaurantContext _context;

        public PolozkasController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Polozkas
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Polozka.Include(p => p.DodavatelNavigation).Include(p => p.Tax);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Polozkas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polozka = await _context.Polozka
                .Include(p => p.DodavatelNavigation)
                .Include(p => p.Tax)
                .FirstOrDefaultAsync(m => m.PolozkaId == id);
            if (polozka == null)
            {
                return NotFound();
            }

            return View(polozka);
        }

        // GET: Polozkas/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Create()
        {
            ViewData["Dodavatel"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId");
            ViewData["TaxId"] = new SelectList(_context.Tax, "TaxId", "Popis");
            return View();
        }

        // POST: Polozkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolozkaId,Nazev,Zasoba,Cena,TaxId,Dodavatel,NakupniCena,MernaHodnota")] Polozka polozka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polozka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dodavatel"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", polozka.Dodavatel);
            ViewData["TaxId"] = new SelectList(_context.Tax, "TaxId", "Popis", polozka.TaxId);
            return View(polozka);
        }

        // GET: Polozkas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polozka = await _context.Polozka.FindAsync(id);
            if (polozka == null)
            {
                return NotFound();
            }
            ViewData["Dodavatel"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", polozka.Dodavatel);
            ViewData["TaxId"] = new SelectList(_context.Tax, "TaxId", "Popis", polozka.TaxId);
            return View(polozka);
        }

        // POST: Polozkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PolozkaId,Nazev,Zasoba,Cena,TaxId,Dodavatel,NakupniCena,MernaHodnota")] Polozka polozka)
        {
            if (id != polozka.PolozkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polozka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolozkaExists(polozka.PolozkaId))
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
            ViewData["Dodavatel"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", polozka.Dodavatel);
            ViewData["TaxId"] = new SelectList(_context.Tax, "TaxId", "Popis", polozka.TaxId);
            return View(polozka);
        }

        // GET: Polozkas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polozka = await _context.Polozka
                .Include(p => p.DodavatelNavigation)
                .Include(p => p.Tax)
                .FirstOrDefaultAsync(m => m.PolozkaId == id);
            if (polozka == null)
            {
                return NotFound();
            }

            return View(polozka);
        }

        // POST: Polozkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var polozka = await _context.Polozka.FindAsync(id);
            _context.Polozka.Remove(polozka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolozkaExists(long id)
        {
            return _context.Polozka.Any(e => e.PolozkaId == id);
        }
    }
}
