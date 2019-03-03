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
    public class KuchynsController : Controller
    {
        private readonly RestaurantContext _context;

        public KuchynsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Kuchyns
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Kuchyn.Include(k => k.Status);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Kuchyns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuchyn = await _context.Kuchyn
                .Include(k => k.Status)
                .FirstOrDefaultAsync(m => m.IdObjPol1 == id);
            if (kuchyn == null)
            {
                return NotFound();
            }

            return View(kuchyn);
        }

        // GET: Kuchyns/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id");
            return View();
        }

        // POST: Kuchyns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObjPol1,StatusId")] Kuchyn kuchyn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kuchyn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", kuchyn.StatusId);
            return View(kuchyn);
        }

        // GET: Kuchyns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuchyn = await _context.Kuchyn.FindAsync(id);
            if (kuchyn == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", kuchyn.StatusId);
            return View(kuchyn);
        }

        // POST: Kuchyns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObjPol1,StatusId")] Kuchyn kuchyn)
        {
            if (id != kuchyn.IdObjPol1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kuchyn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuchynExists(kuchyn.IdObjPol1))
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
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", kuchyn.StatusId);
            return View(kuchyn);
        }

        // GET: Kuchyns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuchyn = await _context.Kuchyn
                .Include(k => k.Status)
                .FirstOrDefaultAsync(m => m.IdObjPol1 == id);
            if (kuchyn == null)
            {
                return NotFound();
            }

            return View(kuchyn);
        }

        // POST: Kuchyns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kuchyn = await _context.Kuchyn.FindAsync(id);
            _context.Kuchyn.Remove(kuchyn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuchynExists(int id)
        {
            return _context.Kuchyn.Any(e => e.IdObjPol1 == id);
        }
    }
}
