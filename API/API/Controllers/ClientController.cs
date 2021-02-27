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
    public class ClientController : ControllerBase
    {
        private readonly SupportContext _context;

        public ClientController()
        {
            _context = new SupportContext();
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetId(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

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
        public async Task<ActionResult<Client>> Post(Client client)
        {
            _context.Clients.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(client.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool Exists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
