using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public JobsAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/JobsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetJobs()
        {
            var result = await (from j in _context.Jobs
                                select new
                                {
                                    j.Id,
                                    j.Job
                                }).ToListAsync();
            return Ok(result);

            //return await _context.Jobs.ToListAsync();
        }

        // GET: api/JobsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobs>> GetJobs(long id)
        {
            var result = await (from j in _context.Jobs
                                where j.Id == id
                                select new
                                {
                                    j.Id,
                                    j.Job
                                }).ToListAsync();
            return Ok(result);
            //var jobs = await _context.Jobs.FindAsync(id);

            //if (jobs == null)
            //{
            //    return NotFound();
            //}

            //return jobs;
        }

        // PUT: api/JobsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobs(long id, Jobs jobs)
        {
            if (id != jobs.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsExists(id))
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

        // POST: api/JobsAPI
        [HttpPost]
        public async Task<ActionResult<Jobs>> PostJobs(Jobs jobs)
        {
            _context.Jobs.Add(jobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobs", new { id = jobs.Id }, jobs);
        }

        // DELETE: api/JobsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jobs>> DeleteJobs(long id)
        {
            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(jobs);
            await _context.SaveChangesAsync();

            return jobs;
        }

        private bool JobsExists(long id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
