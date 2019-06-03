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
    public class TimesheetsAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public TimesheetsAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/TimesheetsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timesheet>>> GetTimesheet()
        {
            return await _context.Timesheet.ToListAsync();
        }

        // GET: api/TimesheetsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timesheet>> GetTimesheet(long id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);

            if (timesheet == null)
            {
                return NotFound();
            }

            return timesheet;
        }

        // PUT: api/TimesheetsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet(long id, Timesheet timesheet)
        {
            if (id != timesheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timesheet).State = EntityState.Modified;

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

        // POST: api/TimesheetsAPI
        [HttpPost]
        public async Task<ActionResult<Timesheet>> PostTimesheet(Timesheet timesheet)
        {
            _context.Timesheet.Add(timesheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesheet", new { id = timesheet.Id }, timesheet);
        }

        // DELETE: api/TimesheetsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Timesheet>> DeleteTimesheet(long id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.Timesheet.Remove(timesheet);
            await _context.SaveChangesAsync();

            return timesheet;
        }

        private bool TimesheetExists(long id)
        {
            return _context.Timesheet.Any(e => e.Id == id);
        }
    }
}
