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
    public class DodavatelsController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public DodavatelsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Dodavatels
        [HttpGet]
        public IEnumerable<Dodavatel> GetDodavatel()
        {
            return _context.Dodavatel;
        }

        // GET: api/Dodavatels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDodavatel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dodavatel = await _context.Dodavatel.FindAsync(id);

            if (dodavatel == null)
            {
                return NotFound();
            }

            return Ok(dodavatel);
        }

        // PUT: api/Dodavatels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDodavatel([FromRoute] int id, [FromBody] Dodavatel dodavatel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dodavatel.DodavatelId)
            {
                return BadRequest();
            }

            _context.Entry(dodavatel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DodavatelExists(id))
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

        // POST: api/Dodavatels
        [HttpPost]
        public async Task<IActionResult> PostDodavatel([FromBody] Dodavatel dodavatel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dodavatel.Add(dodavatel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDodavatel", new { id = dodavatel.DodavatelId }, dodavatel);
        }

        // DELETE: api/Dodavatels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDodavatel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dodavatel = await _context.Dodavatel.FindAsync(id);
            if (dodavatel == null)
            {
                return NotFound();
            }

            _context.Dodavatel.Remove(dodavatel);
            await _context.SaveChangesAsync();

            return Ok(dodavatel);
        }

        private bool DodavatelExists(int id)
        {
            return _context.Dodavatel.Any(e => e.DodavatelId == id);
        }
    }
}