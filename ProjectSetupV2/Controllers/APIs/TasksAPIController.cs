using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Jwt;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers.APIs
{
    [Authorize(AuthenticationSchemes = NetCoreJwtDefaults.SchemeName)]
    [Route("api/jobs/tasks")]
    [ApiController]
    public class TasksAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public TasksAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/TasksAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            var result = await (from r in _context.Tasks
                                select new
                                {
                                    r.Id,
                                    r.Task,
                                    r.JobId

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/TasksAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
            var result = await (from r in _context.Tasks
                                where r.Id == id
                                select new
                                {
                                    r.Id,
                                    r.Task,
                                    r.JobId

                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/TasksAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
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

        // POST: api/TasksAPI
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTasks(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = tasks.Id }, tasks);
        }

        // DELETE: api/TasksAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasks>> DeleteTasks(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return tasks;
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
