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
    public class PozicesController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public PozicesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Pozices
        [HttpGet]
        public IEnumerable<Pozice> GetPozice()
        {
            return _context.Pozice;
        }

        // GET: api/Pozices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPozice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pozice = await _context.Pozice.FindAsync(id);

            if (pozice == null)
            {
                return NotFound();
            }

            return Ok(pozice);
        }

        // PUT: api/Pozices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozice([FromRoute] int id, [FromBody] Pozice pozice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pozice.PoziceId)
            {
                return BadRequest();
            }

            _context.Entry(pozice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoziceExists(id))
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

        // POST: api/Pozices
        [HttpPost]
        public async Task<IActionResult> PostPozice([FromBody] Pozice pozice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pozice.Add(pozice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozice", new { id = pozice.PoziceId }, pozice);
        }

        // DELETE: api/Pozices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePozice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pozice = await _context.Pozice.FindAsync(id);
            if (pozice == null)
            {
                return NotFound();
            }

            _context.Pozice.Remove(pozice);
            await _context.SaveChangesAsync();

            return Ok(pozice);
        }

        private bool PoziceExists(int id)
        {
            return _context.Pozice.Any(e => e.PoziceId == id);
        }
    }
}