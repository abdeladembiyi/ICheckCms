using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iCheckAPI.Models;

namespace iCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePermisController : ControllerBase
    {
        private readonly icheckcmsContext _context;

        public TypePermisController(icheckcmsContext context)
        {
            _context = context;
        }

        // GET: api/TypePermis
        [HttpGet]
        public IEnumerable<TypePermis> GetTypePermis()
        {
            return _context.TypePermis;
        }

        // GET: api/TypePermis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypePermis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typePermis = await _context.TypePermis.FindAsync(id);

            if (typePermis == null)
            {
                return NotFound();
            }

            return Ok(typePermis);
        }

        // PUT: api/TypePermis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePermis([FromRoute] int id, [FromBody] TypePermis typePermis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typePermis.Idpermis)
            {
                return BadRequest();
            }

            _context.Entry(typePermis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePermisExists(id))
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

        // POST: api/TypePermis
        [HttpPost]
        public async Task<IActionResult> PostTypePermis([FromBody] TypePermis typePermis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TypePermis.Add(typePermis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePermis", new { id = typePermis.Idpermis }, typePermis);
        }

        // DELETE: api/TypePermis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePermis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typePermis = await _context.TypePermis.FindAsync(id);
            if (typePermis == null)
            {
                return NotFound();
            }

            _context.TypePermis.Remove(typePermis);
            await _context.SaveChangesAsync();

            return Ok(typePermis);
        }

        private bool TypePermisExists(int id)
        {
            return _context.TypePermis.Any(e => e.Idpermis == id);
        }
    }
}