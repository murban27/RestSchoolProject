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
    public class DodavatelsController : Controller
    {
        private readonly RestaurantContext _context;

        public DodavatelsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Dodavatels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dodavatel.ToListAsync());
        }

        // GET: Dodavatels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodavatel = await _context.Dodavatel
                .FirstOrDefaultAsync(m => m.DodavatelId == id);
            if (dodavatel == null)
            {
                return NotFound();
            }

            return View(dodavatel);
        }

        // GET: Dodavatels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dodavatels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DodavatelId,Nazev,Adresa")] Dodavatel dodavatel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodavatel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodavatel);
        }

        // GET: Dodavatels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodavatel = await _context.Dodavatel.FindAsync(id);
            if (dodavatel == null)
            {
                return NotFound();
            }
            return View(dodavatel);
        }

        // POST: Dodavatels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DodavatelId,Nazev,Adresa")] Dodavatel dodavatel)
        {
            if (id != dodavatel.DodavatelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodavatel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodavatelExists(dodavatel.DodavatelId))
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
            return View(dodavatel);
        }

        // GET: Dodavatels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodavatel = await _context.Dodavatel
                .FirstOrDefaultAsync(m => m.DodavatelId == id);
            if (dodavatel == null)
            {
                return NotFound();
            }

            return View(dodavatel);
        }

        // POST: Dodavatels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dodavatel = await _context.Dodavatel.FindAsync(id);
            _context.Dodavatel.Remove(dodavatel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodavatelExists(int id)
        {
            return _context.Dodavatel.Any(e => e.DodavatelId == id);
        }
    }
}
