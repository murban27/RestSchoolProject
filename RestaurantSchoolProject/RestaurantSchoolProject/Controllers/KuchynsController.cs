using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSchoolProject.Models;

namespace RestaurantSchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class KuchynsController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public KuchynsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Kuchyns
        [HttpGet]
        public IEnumerable<Kuchyn> GetKuchyn()
        {
            return _context.Kuchyn;
        }

        // GET: api/Kuchyns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKuchyn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kuchyn = await _context.Kuchyn.FindAsync(id);

            if (kuchyn == null)
            {
                return NotFound();
            }

            return Ok(kuchyn);
        }

        // PUT: api/Kuchyns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKuchyn([FromRoute] int id, [FromBody] Kuchyn kuchyn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kuchyn.IdObjPol1)
            {
                return BadRequest();
            }

            _context.Entry(kuchyn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KuchynExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kuchyns
        [HttpPost]
        public async Task<IActionResult> PostKuchyn([FromBody] Kuchyn kuchyn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kuchyn.Add(kuchyn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKuchyn", new { id = kuchyn.IdObjPol1 }, kuchyn);
        }

        // DELETE: api/Kuchyns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKuchyn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kuchyn = await _context.Kuchyn.FindAsync(id);
            if (kuchyn == null)
            {
                return NotFound();
            }

            _context.Kuchyn.Remove(kuchyn);
            await _context.SaveChangesAsync();

            return Ok(kuchyn);
        }

        private bool KuchynExists(int id)
        {
            return _context.Kuchyn.Any(e => e.IdObjPol1 == id);
        }
    }
}