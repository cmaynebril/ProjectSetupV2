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
    [Route("api/typesOfLeaves")]
    [ApiController]
    public class TypesOfLeavesAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public TypesOfLeavesAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/TypesOfLeavesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypesOfLeave>>> GetTypesOfLeave()
        {
            return await _context.TypesOfLeave.ToListAsync();
        }

        // GET: api/TypesOfLeavesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypesOfLeave>> GetTypesOfLeave(int id)
        {
            var typesOfLeave = await _context.TypesOfLeave.FindAsync(id);

            if (typesOfLeave == null)
            {
                return NotFound();
            }

            return typesOfLeave;
        }

        // PUT: api/TypesOfLeavesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypesOfLeave(int id, TypesOfLeave typesOfLeave)
        {
            if (id != typesOfLeave.Id)
            {
                return BadRequest();
            }

            _context.Entry(typesOfLeave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesOfLeaveExists(id))
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

        // POST: api/TypesOfLeavesAPI
        [HttpPost]
        public async Task<ActionResult<TypesOfLeave>> PostTypesOfLeave(TypesOfLeave typesOfLeave)
        {
            _context.TypesOfLeave.Add(typesOfLeave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypesOfLeave", new { id = typesOfLeave.Id }, typesOfLeave);
        }

        // DELETE: api/TypesOfLeavesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypesOfLeave>> DeleteTypesOfLeave(int id)
        {
            var typesOfLeave = await _context.TypesOfLeave.FindAsync(id);
            if (typesOfLeave == null)
            {
                return NotFound();
            }

            _context.TypesOfLeave.Remove(typesOfLeave);
            await _context.SaveChangesAsync();

            return typesOfLeave;
        }

        private bool TypesOfLeaveExists(int id)
        {
            return _context.TypesOfLeave.Any(e => e.Id == id);
        }
    }
}
