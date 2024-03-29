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
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public ProjectsAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/ProjectsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetProjects()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/ProjectsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobs>> GetProjects(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/ProjectsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects(int id, Jobs jobs)
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
                if (!ProjectsExists(id))
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

        // POST: api/ProjectsAPI
        [HttpPost]
        public async Task<ActionResult<Jobs>> PostProjects(Jobs jobs)
        {
            _context.Jobs.Add(jobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjects", new { id = jobs.Id }, jobs);
        }

        // DELETE: api/ProjectsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jobs>> DeleteProjects(int id)
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

        private bool ProjectsExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
