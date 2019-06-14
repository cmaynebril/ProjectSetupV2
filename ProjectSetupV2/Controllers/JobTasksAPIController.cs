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
    [Route("api/jobs/user/tasks/fill")]
    [ApiController]
    public class JobTasksAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public JobTasksAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/jobs/user/tasks/fill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTasks>>> GetTimesheet()
        {
            //return _context.JobTasks
            //  .Include(a => a.Id)
            var result = await (from a in _context.JobTasks
                                select new
                                {
                                    a.Id,
                                    task = new {
                                        a.Task.Id,
                                        a.Task.Task,
                                        a.Task.JobId
                                    },
                                    a.Description,
                                    a.Status,
                                    a.TotalTime,
                                    Jobs = new {
                                        a.Job.Id,
                                        a.Job.Job
                                    },
                                    Clients = new {
                                        a.Client.Id,
                                        a.Client.Client
                                    },
                                    BusinessValues = new {
                                        a.BusinessValue.Id,
                                        a.BusinessValue.Business,
                                        a.BusinessValue.Rate
                                    },
                                    Assignee = new {
                                        a.Assignee.Id,
                                        a.Assignee.Assignee
                                    }

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/jobs/user/tasks/fill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTasks>> GetTimesheet(long id)
        {
            var result = await (from a in _context.JobTasks
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    task = new
                                    {
                                        a.Task.Id,
                                        a.Task.Task,
                                        a.Task.JobId
                                    },
                                    a.Description,
                                    a.Status,
                                    a.TotalTime,
                                    Jobs = new
                                    {
                                        a.Job.Id,
                                        a.Job.Job
                                    },
                                    Clients = new
                                    {
                                        a.Client.Id,
                                        a.Client.Client
                                    },
                                    BusinessValues = new
                                    {
                                        a.BusinessValue.Id,
                                        a.BusinessValue.Business,
                                        a.BusinessValue.Rate
                                    },
                                    Assignees = new
                                    {
                                        a.Assignee.Id,
                                        a.Assignee.Assignee
                                    }

                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/JobTasksAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet(long id, JobTasks jobTasks)
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
                if (!TimesheetExists(id))
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

        // POST: api/JobTasksAPI
        [HttpPost]
        public async Task<ActionResult<JobTasks>> PostTimesheet(JobTasks jobTasks)
        {
            _context.JobTasks.Add(jobTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesheet", new { id = jobTasks.Id }, jobTasks);
        }

        // DELETE: api/JobTasksAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobTasks>> DeleteTimesheet(long id)
        {
            var timesheet = await _context.JobTasks.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.JobTasks.Remove(timesheet);
            await _context.SaveChangesAsync();

            return timesheet;
        }

        private bool TimesheetExists(long id)
        {
            return _context.JobTasks.Any(e => e.Id == id);
        }
    }
}
