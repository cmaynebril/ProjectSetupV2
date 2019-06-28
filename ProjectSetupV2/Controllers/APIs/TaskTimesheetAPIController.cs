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
        public async Task<ActionResult<IEnumerable<TaskTimesheet>>> GetTaskTimesheet()
        {
            var result = await (from a in _context.TaskTimesheet
                                select new
                                {
                                    a.Id,
                                    a.Client.Client,
                                    a.Job.Job,
                                    a.Description,
                                    a.Task.Task,
                                    a.Status,
                                    DateCreated = a.DateCreated.Value.ToString("yyyy-MM-dd"),
                                    a.Billable,
                                    a.StartTime,
                                    a.EndTime,
                                    totalTimeSpent = a.TotalTimeSpent,
                                    a.BusinessValueId,
                                    invoiceTypeId = new
                                    {
                                        a.Task.InvoiceType.Id,
                                        a.Task.InvoiceType.Type,
                                    },
                                    assigneeId = new {
                                        a.User.Id,
                                        a.User.UserName
                                    }

                                }).ToListAsync();
           
            return Ok(result);
        }

        // GET: api/user/timesheet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTimesheet>> GetTaskTimesheet(int id)
        {
            var result = await (from a in _context.TaskTimesheet
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    a.Client.Client,
                                    a.Job.Job,
                                    a.Description,
                                    a.Task.Task,
                                    a.Status,
                                    DateCreated = a.DateCreated.Value.ToString("yyyy-MM-dd"),
                                    a.Billable,
                                    a.StartTime,
                                    a.EndTime,
                                    totalTimeSpent = a.TotalTimeSpent,
                                    a.BusinessValueId,
                                    invoiceTypeId = new
                                    {
                                        a.Task.InvoiceType.Id,
                                        a.Task.InvoiceType.Type,
                                        
                                    },
                                    assigneeId = new
                                    {
                                        a.User.Id,
                                        a.User.UserName
                                    }
                                }).ToListAsync();
            return Ok(result);
        }

        // POST: api/user/timesheet
        [HttpPost]
        public async Task<ActionResult<TaskTimesheet>> PostTaskTimesheet(TaskTimesheet taskTimesheet)
        {
            _context.TaskTimesheet.Add(taskTimesheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskTimesheet", new { id = taskTimesheet.Id }, taskTimesheet);
        }

        // DELETE: api/user/timesheet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskTimesheet>> DeleteTaskTimesheet(int id)
        {
            var taskTimesheet = await _context.JobTasks.FindAsync(id);
            if (taskTimesheet == null)
            {
                return NotFound();
            }

            _context.JobTasks.Remove(taskTimesheet);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }
    }
}
