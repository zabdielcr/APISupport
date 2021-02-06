using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppiSupport1.Models;

namespace AppiSupport1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupporterController : ControllerBase
    {
        private readonly dbSupportContext _context;

        public SupporterController()
        {
            _context = new dbSupportContext();
        }

        // GET: api/Supporter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supporter>>> GetAllSupporter()
        {
            return await _context.Supporters.ToListAsync();
        }

        // GET: api/Supporter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supporter>> GetSupporter(int id)
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
        public async Task<IActionResult> Put(int id, Supporter supporter)
        {
            if (id != supporter.Id)
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
        public async Task<ActionResult<Supporter>> Post(Supporter supporter)
        {
            _context.Supporters.Add(supporter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupporter", new { id = supporter.Id }, supporter);
        }

        // DELETE: api/Supporter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supporter>> Delete(int id)
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

        private bool SupporterExists(int id)
        {
            return _context.Supporters.Any(e => e.Id == id);
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Supporter> GetAll()
        {
            try
            {
                return _context.Supporters.OrderBy(a => a.Name);

            }
            catch
            {
                throw;
            }
        }



        [Route("[action]")]
        [HttpGet]
        private Supporter GetToAuthenticate(string email, string password)
        {

            var supporter = _context.Supporters.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).Single();

            return supporter;
        }
    }
}
