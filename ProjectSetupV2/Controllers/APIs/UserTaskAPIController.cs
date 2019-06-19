using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers.APIs
{
    [Route("api/jobs/user/tasks")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public UserTaskController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/jobs/user/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTasks>>> GetJobTasks()
        {
            var result = await (from a in _context.JobTasks
                                select new
                                {
                                    a.Id,
                                    taskId = a.Task.Id,
                                    status = a.Status,
                                    description = a.Description,
                                    timeSpent = a.TimeSpent,
                                    jobId = a.Job.Id,
                                    clientId = a.Client.Id,
                                    businessValueId = a.BusinessValue.Id,
                                    assigneeId = a.Assignee.Id

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/jobs/user/tasks/5
        // filtered by jobId
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTasks>> GetJobTasks(int id)
        {
            var result = await (from a in _context.JobTasks
                                where (a.Job.Id == id)
                                select new
                                {
                                    a.Id,
                                    taskId = a.Task.Id,
                                    status = a.Status,
                                    description = a.Description,
                                    timeSpent = a.TimeSpent,
                                    jobId = a.Job.Id,
                                    clientId = a.Client.Id,
                                    businessValueId = a.BusinessValue.Id,
                                    assigneeId = a.Assignee.Id

                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/UserTask/5
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

        // POST: api/UserTask
        [HttpPost]
        public async Task<ActionResult<JobTasks>> PostJobTasks(JobTasks jobTasks)
        {
            _context.JobTasks.Add(jobTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTasks", new { id = jobTasks.Id }, jobTasks);
        }

        // DELETE: api/UserTask/5
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
