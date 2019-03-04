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
    [Authorize]
    public class PolozkasController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public PolozkasController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Polozkas
        [HttpGet]
        public IEnumerable<Polozka> GetPolozka()
        {
            return _context.Polozka;
        }

        // GET: api/Polozkas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolozka([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var polozka = await _context.Polozka.FindAsync(id);

            if (polozka == null)
            {
                return NotFound();
            }

            return Ok(polozka);
        }

        // PUT: api/Polozkas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolozka([FromRoute] long id, [FromBody] Polozka polozka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != polozka.PolozkaId)
            {
                return BadRequest();
            }

            _context.Entry(polozka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolozkaExists(id))
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

        // POST: api/Polozkas
        [HttpPost]
        public async Task<IActionResult> PostPolozka([FromBody] Polozka polozka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Polozka.Add(polozka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolozka", new { id = polozka.PolozkaId }, polozka);
        }

        // DELETE: api/Polozkas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolozka([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var polozka = await _context.Polozka.FindAsync(id);
            if (polozka == null)
            {
                return NotFound();
            }

            _context.Polozka.Remove(polozka);
            await _context.SaveChangesAsync();

            return Ok(polozka);
        }

        private bool PolozkaExists(long id)
        {
            return _context.Polozka.Any(e => e.PolozkaId == id);
        }
    }
}