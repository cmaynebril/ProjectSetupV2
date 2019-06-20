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
    public class TaskTimesheetsController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public TaskTimesheetsController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/TaskTimesheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTimesheet>>> GetTaskTimesheet()
        {
            return await _context.TaskTimesheet.ToListAsync();
        }

        // GET: api/TaskTimesheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTimesheet>> GetTaskTimesheet(int id)
        {
            var taskTimesheet = await _context.TaskTimesheet.FindAsync(id);

            if (taskTimesheet == null)
            {
                return NotFound();
            }

            return taskTimesheet;
        }

        // PUT: api/TaskTimesheets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskTimesheet(int id, TaskTimesheet taskTimesheet)
        {
            if (id != taskTimesheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskTimesheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTimesheetExists(id))
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

        // POST: api/TaskTimesheets
        [HttpPost]
        public async Task<ActionResult<TaskTimesheet>> PostTaskTimesheet(TaskTimesheet taskTimesheet)
        {
            _context.TaskTimesheet.Add(taskTimesheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskTimesheet", new { id = taskTimesheet.Id }, taskTimesheet);
        }

        // DELETE: api/TaskTimesheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskTimesheet>> DeleteTaskTimesheet(int id)
        {
            var taskTimesheet = await _context.TaskTimesheet.FindAsync(id);
            if (taskTimesheet == null)
            {
                return NotFound();
            }

            _context.TaskTimesheet.Remove(taskTimesheet);
            await _context.SaveChangesAsync();

            return taskTimesheet;
        }

        private bool TaskTimesheetExists(int id)
        {
            return _context.TaskTimesheet.Any(e => e.Id == id);
        }
    }
}
