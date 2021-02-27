using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupporterController : ControllerBase
    {
        private readonly SupportContext _context;

        public SupporterController()
        {
            _context = new SupportContext();
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supporter>>> Get()
        {
            return await _context.Supporters.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Supporter>> GetId(int id)
        {
            var supporter = await _context.Supporters.FindAsync(id);

            if (supporter == null)
            {
                return NotFound();
            }

            return supporter;
        }

    
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
                if (!Exists(id))
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

    
        [HttpPost]
        public async Task<ActionResult<Supporter>> Post(Supporter supporter)
        {
            _context.Supporters.Add(supporter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupporter", new { id = supporter.Id }, supporter);
        }

     
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

        private bool Exists(int id)
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
