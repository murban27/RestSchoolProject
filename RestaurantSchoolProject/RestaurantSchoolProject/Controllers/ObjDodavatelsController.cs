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
    public class ObjDodavatelsController : Controller
    {
        private readonly RestaurantContext _context;

        public ObjDodavatelsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: ObjDodavatels
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.ObjDodavatel.Include(o => o.Dodavatel).Include(o => o.Status);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: ObjDodavatels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objDodavatel = await _context.ObjDodavatel
                .Include(o => o.Dodavatel)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.ObjId == id);
            if (objDodavatel == null)
            {
                return NotFound();
            }

            return View(objDodavatel);
        }

        // GET: ObjDodavatels/Create
        public IActionResult Create()
        {
            ViewData["DodavatelId"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId");
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id");
            return View();
        }

        // POST: ObjDodavatels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjId,DatumObjednani,StatusId,DodavatelId")] ObjDodavatel objDodavatel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objDodavatel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DodavatelId"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", objDodavatel.DodavatelId);
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", objDodavatel.StatusId);
            return View(objDodavatel);
        }

        // GET: ObjDodavatels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objDodavatel = await _context.ObjDodavatel.FindAsync(id);
            if (objDodavatel == null)
            {
                return NotFound();
            }
            ViewData["DodavatelId"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", objDodavatel.DodavatelId);
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", objDodavatel.StatusId);
            return View(objDodavatel);
        }

        // POST: ObjDodavatels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjId,DatumObjednani,StatusId,DodavatelId")] ObjDodavatel objDodavatel)
        {
            if (id != objDodavatel.ObjId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objDodavatel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjDodavatelExists(objDodavatel.ObjId))
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
            ViewData["DodavatelId"] = new SelectList(_context.Dodavatel, "DodavatelId", "DodavatelId", objDodavatel.DodavatelId);
            ViewData["StatusId"] = new SelectList(_context.StatusZpravy, "Id", "Id", objDodavatel.StatusId);
            return View(objDodavatel);
        }

        // GET: ObjDodavatels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objDodavatel = await _context.ObjDodavatel
                .Include(o => o.Dodavatel)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.ObjId == id);
            if (objDodavatel == null)
            {
                return NotFound();
            }

            return View(objDodavatel);
        }

        // POST: ObjDodavatels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objDodavatel = await _context.ObjDodavatel.FindAsync(id);
            _context.ObjDodavatel.Remove(objDodavatel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjDodavatelExists(int id)
        {
            return _context.ObjDodavatel.Any(e => e.ObjId == id);
        }
    }
}
