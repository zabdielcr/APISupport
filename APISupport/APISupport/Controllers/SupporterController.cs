using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISupport.Models;

namespace APISupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupporterController : ControllerBase
    {
        private readonly dbSupportContext _context;

        public SupporterController(dbSupportContext context)
        {
            _context = context;
        }

        // GET: api/Supporter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supporter>>> GetSupporters()
        {
            return await _context.Supporters.ToListAsync();
        }

        // GET: api/Supporter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supporter>> GetSupporter(string id)
        {
            var supporter = await _context.Supporters.FindAsync(id);

            if (supporter == null)
            {
                return NotFound();
            }

            return supporter;
        }

        // PUT: api/Supporter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupporter(string id, Supporter supporter)
        {
            if (id != supporter.Email)
            {
                return BadRequest();
            }

            _context.Entry(supporter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupporterExists(id))
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

        // POST: api/Supporter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Supporter>> PostSupporter(Supporter supporter)
        {
            _context.Supporters.Add(supporter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupporterExists(supporter.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSupporter", new { id = supporter.Email }, supporter);
        }

        // DELETE: api/Supporter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supporter>> DeleteSupporter(string id)
        {
            var supporter = await _context.Supporters.FindAsync(id);
            if (supporter == null)
            {
                return NotFound();
            }

            _context.Supporters.Remove(supporter);
            await _context.SaveChangesAsync();

            return supporter;
        }

        private bool SupporterExists(string id)
        {
            return _context.Supporters.Any(e => e.Email == id);
        }
    }
}
