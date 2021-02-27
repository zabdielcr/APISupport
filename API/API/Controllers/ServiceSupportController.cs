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
    public class ServiceSupportController : ControllerBase
    {
        private readonly SupportContext _context;

        public ServiceSupportController()
        {
            _context = new SupportContext();
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceSupport>>> Get()
        {
            return await _context.ServiceSupports.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceSupport>> GetId(int id)
        {
            var serviceSupport = await _context.ServiceSupports.FindAsync(id);

            if (serviceSupport == null)
            {
                return NotFound();
            }

            return serviceSupport;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ServiceSupport serviceSupport)
        {
            if (id != serviceSupport.IdSupport)
            {
                return BadRequest();
            }

            _context.Entry(serviceSupport).State = EntityState.Modified;

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
        public async Task<ActionResult<ServiceSupport>> Post(ServiceSupport serviceSupport)
        {
            _context.ServiceSupports.Add(serviceSupport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(serviceSupport.IdSupport))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiceSupport", new { id = serviceSupport.IdSupport }, serviceSupport);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceSupport>> Delete(int id)
        {
            var serviceSupport = await _context.ServiceSupports.FindAsync(id);
            if (serviceSupport == null)
            {
                return NotFound();
            }

            _context.ServiceSupports.Remove(serviceSupport);
            await _context.SaveChangesAsync();

            return serviceSupport;
        }

        private bool Exists(int id)
        {
            return _context.ServiceSupports.Any(e => e.IdSupport == id);
        }
    }
}
