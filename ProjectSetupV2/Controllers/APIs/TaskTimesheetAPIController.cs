﻿using System;
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
        public async Task<ActionResult<IEnumerable<JobTasks>>> GetJobTasks()
        {
            var result = await (from a in _context.JobTasks
                                select new
                                {
                                    a.Id,
                                    a.Client.Client,
                                    a.Job.Job,
                                    a.Task.Task,
                                    Date = a.Date.Value.ToString("yyyy-MM-dd"),
                                    totalTimeSpent = a.TimeSpent,
                                    assigneeId = a.Assignee.Id

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/TaskTimesheetAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTasks>> GetJobTasks(int id)
        {
            var result = await (from a in _context.JobTasks
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    a.Client.Client,
                                    a.Job.Job,
                                    a.Task.Task,
                                    a.Date,
                                    totalTimeSpent = a.TimeSpent,
                                    assigneeId = a.Assignee.Id

                                }).ToListAsync();
            return Ok(result);
        }
    }
}