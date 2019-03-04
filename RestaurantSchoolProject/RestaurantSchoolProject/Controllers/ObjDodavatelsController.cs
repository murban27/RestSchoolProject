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
    [Authorize(Roles = "0")]
    public class ObjDodavatelsController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public ObjDodavatelsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/ObjDodavatels
        [HttpGet]
        public IEnumerable<ObjDodavatel> GetObjDodavatel()
        {
            return _context.ObjDodavatel;
        }

        // GET: api/ObjDodavatels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjDodavatel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objDodavatel = await _context.ObjDodavatel.FindAsync(id);

            if (objDodavatel == null)
            {
                return NotFound();
            }

            return Ok(objDodavatel);
        }

        // PUT: api/ObjDodavatels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjDodavatel([FromRoute] int id, [FromBody] ObjDodavatel objDodavatel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objDodavatel.ObjId)
            {
                return BadRequest();
            }

            _context.Entry(objDodavatel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjDodavatelExists(id))
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

        // POST: api/ObjDodavatels
        [HttpPost]
        public async Task<IActionResult> PostObjDodavatel([FromBody] ObjDodavatel objDodavatel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ObjDodavatel.Add(objDodavatel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjDodavatel", new { id = objDodavatel.ObjId }, objDodavatel);
        }

        // DELETE: api/ObjDodavatels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjDodavatel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objDodavatel = await _context.ObjDodavatel.FindAsync(id);
            if (objDodavatel == null)
            {
                return NotFound();
            }

            _context.ObjDodavatel.Remove(objDodavatel);
            await _context.SaveChangesAsync();

            return Ok(objDodavatel);
        }

        private bool ObjDodavatelExists(int id)
        {
            return _context.ObjDodavatel.Any(e => e.ObjId == id);
        }
    }
}