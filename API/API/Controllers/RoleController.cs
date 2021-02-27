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
    public class RoleController : ControllerBase
    {
        private readonly SupportContext _context;

        public RoleController(SupportContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await _context.Roles.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetId(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

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
        public async Task<ActionResult<Role>> Post(Role role)
        {
            _context.Roles.Add(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(role.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return role;
        }

        private bool Exists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
