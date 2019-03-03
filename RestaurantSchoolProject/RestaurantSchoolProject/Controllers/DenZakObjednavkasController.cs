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
    public class DenZakObjednavkasController : Controller
    {
        private readonly RestaurantContext _context;

        public DenZakObjednavkasController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: DenZakObjednavkas
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.DenZakObjednavka.Include(d => d.Status).Include(d => d.Table);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: DenZakObjednavkas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denZakObjednavka = await _context.DenZakObjednavka
                .Include(d => d.Status)
                .Include(d => d.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denZakObjednavka == null)
            {
                return NotFound();
            }

            return View(denZakObjednavka);
        }

        // GET: DenZakObjednavkas/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id");
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id");
            return View();
        }

        // POST: DenZakObjednavkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatumObj,TableId,StatusId,Eet")] DenZakObjednavka denZakObjednavka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denZakObjednavka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", denZakObjednavka.StatusId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", denZakObjednavka.TableId);
            return View(denZakObjednavka);
        }

        // GET: DenZakObjednavkas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denZakObjednavka = await _context.DenZakObjednavka.FindAsync(id);
            if (denZakObjednavka == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", denZakObjednavka.StatusId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", denZakObjednavka.TableId);
            return View(denZakObjednavka);
        }

        // POST: DenZakObjednavkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DatumObj,TableId,StatusId,Eet")] DenZakObjednavka denZakObjednavka)
        {
            if (id != denZakObjednavka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denZakObjednavka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenZakObjednavkaExists(denZakObjednavka.Id))
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
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", denZakObjednavka.StatusId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", denZakObjednavka.TableId);
            return View(denZakObjednavka);
        }

        // GET: DenZakObjednavkas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denZakObjednavka = await _context.DenZakObjednavka
                .Include(d => d.Status)
                .Include(d => d.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denZakObjednavka == null)
            {
                return NotFound();
            }

            return View(denZakObjednavka);
        }

        // POST: DenZakObjednavkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var denZakObjednavka = await _context.DenZakObjednavka.FindAsync(id);
            _context.DenZakObjednavka.Remove(denZakObjednavka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenZakObjednavkaExists(long id)
        {
            return _context.DenZakObjednavka.Any(e => e.Id == id);
        }
    }
}
