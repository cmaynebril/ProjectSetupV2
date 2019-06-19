using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers.APIs
{
    [Route("api/user/leave")]
    [ApiController]
    public class LeavesAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;
        private readonly UserManager<User> _userManager;

        public LeavesAPIController(DBProjectSetupContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/LeavesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeave()
        {
            var result = await (from a in _context.Leave
                                select new
                                {
                                    a.Id,
                                    a.UserId,
                                    Approver = a.LeaveApprover.Select(b => new {
                                        b.ApproverId,
                                        b.Approver,
                                        b.Status
                                    }),
                                    StartDate = a.StartDate.Value.ToShortDateString(),
                                    EndDate = a.EndDate.Value.ToShortDateString(),
                                    a.Reason,
                                    a.Status,
                                    a.TypeOfRequest

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/LeavesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeave(int id)
        {
            var result = await (from a in _context.Leave
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    a.UserId,
                                    Approver = a.LeaveApprover.Select(b => new {
                                        b.ApproverId,
                                        b.Approver,
                                        b.Status
                                    }),
                                    StartDate = a.StartDate.Value.ToShortDateString(),
                                    EndDate = a.EndDate.Value.ToShortDateString(),
                                    a.Reason,
                                    a.Status,
                                    a.TypeOfRequest

                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/LeavesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, Leave leave)
        {
            if (id != leave.Id)
            {
                return BadRequest();
            }

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
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

        // POST: api/LeavesAPI
        [HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            _context.Leave.Add(leave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeave", new { id = leave.Id }, leave);
        }

        // DELETE: api/LeavesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Leave>> DeleteLeave(int id)
        {
            var leave = await _context.Leave.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.Leave.Remove(leave);
            await _context.SaveChangesAsync();

            return leave;
        }

        private bool LeaveExists(int id)
        {
            return _context.Leave.Any(e => e.Id == id);
        }
    }
}
