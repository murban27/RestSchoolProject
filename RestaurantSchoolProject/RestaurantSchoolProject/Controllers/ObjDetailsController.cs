using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSchoolProject.Models;

namespace RestaurantSchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjDetailsController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public ObjDetailsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/ObjDetails
        [HttpGet]
        public IEnumerable<ObjDetail> GetObjDetail()
        {
            return _context.ObjDetail;
        }

        // GET: api/ObjDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objDetail = await _context.ObjDetail.FindAsync(id);

            if (objDetail == null)
            {
                return NotFound();
            }

            return Ok(objDetail);
        }

        // PUT: api/ObjDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjDetail([FromRoute] int id, [FromBody] ObjDetail objDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objDetail.InternalId)
            {
                return BadRequest();
            }

            _context.Entry(objDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjDetailExists(id))
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

        // POST: api/ObjDetails
        [HttpPost]
        public async Task<IActionResult> PostObjDetail([FromBody] ObjDetail objDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ObjDetail.Add(objDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjDetail", new { id = objDetail.InternalId }, objDetail);
        }

        // DELETE: api/ObjDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objDetail = await _context.ObjDetail.FindAsync(id);
            if (objDetail == null)
            {
                return NotFound();
            }

            _context.ObjDetail.Remove(objDetail);
            await _context.SaveChangesAsync();

            return Ok(objDetail);
        }

        private bool ObjDetailExists(int id)
        {
            return _context.ObjDetail.Any(e => e.InternalId == id);
        }
    }
}