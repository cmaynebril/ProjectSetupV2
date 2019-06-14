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
    [Route("api/user/timesheet")]
    [ApiController]
    public class TaskTimesheetAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public TaskTimesheetAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/user/timesheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTasks>>> GetJobTasks()
        {
            var result = await (from a in _context.JobTasks
                                select new
                                {
                                    a.Id,
                                        a.Client.Client,
                                        a.Job.Job,
                                        a.Task.Task,
                                    a.Date,
                                    totalTimeSpent = a.TotalTime,
                                    assigneeId = a.Assignee.Id

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/TaskTimesheetAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTasks>> GetJobTasks(int id)
        {
            var jobTasks = await _context.JobTasks.FindAsync(id);

            if (jobTasks == null)
            {
                return NotFound();
            }

            return jobTasks;
        }

        // PUT: api/TaskTimesheetAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTasks(int id, JobTasks jobTasks)
        {
            if (id != jobTasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTasksExists(id))
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

        // POST: api/TaskTimesheetAPI
        [HttpPost]
        public async Task<ActionResult<JobTasks>> PostJobTasks(JobTasks jobTasks)
        {
            _context.JobTasks.Add(jobTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTasks", new { id = jobTasks.Id }, jobTasks);
        }

        // DELETE: api/TaskTimesheetAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobTasks>> DeleteJobTasks(int id)
        {
            var jobTasks = await _context.JobTasks.FindAsync(id);
            if (jobTasks == null)
            {
                return NotFound();
            }

            _context.JobTasks.Remove(jobTasks);
            await _context.SaveChangesAsync();

            return jobTasks;
        }

        private bool JobTasksExists(int id)
        {
            return _context.JobTasks.Any(e => e.Id == id);
        }
    }
}
