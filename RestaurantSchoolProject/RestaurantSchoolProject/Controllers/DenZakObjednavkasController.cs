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
    public class DenZakObjednavkasController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public DenZakObjednavkasController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/DenZakObjednavkas
        [HttpGet]

        public IEnumerable<DenZakObjednavka> GetDenZakObjednavka()
        {
            return _context.DenZakObjednavka;
        }

        // GET: api/DenZakObjednavkas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenZakObjednavka([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var denZakObjednavka = await _context.DenZakObjednavka.FindAsync(id);

            if (denZakObjednavka == null)
            {
                return NotFound();
            }

            return Ok(denZakObjednavka);
        }

        // PUT: api/DenZakObjednavkas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDenZakObjednavka([FromRoute] long id, [FromBody] DenZakObjednavka denZakObjednavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denZakObjednavka.Id)
            {
                return BadRequest();
            }

            _context.Entry(denZakObjednavka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenZakObjednavkaExists(id))
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

        // POST: api/DenZakObjednavkas
        [HttpPost]
        public async Task<IActionResult> PostDenZakObjednavka([FromBody] DenZakObjednavka denZakObjednavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DenZakObjednavka.Add(denZakObjednavka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDenZakObjednavka", new { id = denZakObjednavka.Id }, denZakObjednavka);
        }

        // DELETE: api/DenZakObjednavkas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDenZakObjednavka([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var denZakObjednavka = await _context.DenZakObjednavka.FindAsync(id);
            if (denZakObjednavka == null)
            {
                return NotFound();
            }

            _context.DenZakObjednavka.Remove(denZakObjednavka);
            await _context.SaveChangesAsync();

            return Ok(denZakObjednavka);
        }

        private bool DenZakObjednavkaExists(long id)
        {
            return _context.DenZakObjednavka.Any(e => e.Id == id);
        }
    }
}