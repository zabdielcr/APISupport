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
    public class IssueController : ControllerBase
    {
        private readonly SupportContext _context;

        public IssueController()
        {
            _context = new SupportContext();
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> Get()
        {
            return await _context.Issues.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetId(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Issue issue)
        {
            if (id != issue.ReportNumber)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

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
        public async Task<ActionResult<Issue>> Post(Issue issue)
        {
            _context.Issues.Add(issue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(issue.ReportNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIssue", new { id = issue.ReportNumber }, issue);
        }

    
        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> Delete(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool Exists(int id)
        {
            return _context.Issues.Any(e => e.ReportNumber == id);
        }
    }
}
