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
    public class AssignmentController : ControllerBase
    {
        private readonly SupportContext _context;

        public AssignmentController()
        {
            _context =  new SupportContext();
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> Get()
        {
            return await _context.Assignments.ToListAsync();
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetId(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Assignment assignment)
        {
            if (id != assignment.IdIssue)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

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
        public async Task<ActionResult<Assignment>> Post(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(assignment.IdIssue))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssignment", new { id = assignment.IdIssue }, assignment);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assignment>> Delete(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }

        private bool Exists(int id)
        {
            return _context.Assignments.Any(e => e.IdIssue == id);
        }
    }
}
