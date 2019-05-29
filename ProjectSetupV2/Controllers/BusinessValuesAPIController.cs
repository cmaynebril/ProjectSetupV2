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
    public class BusinessValuesAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public BusinessValuesAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/BusinessValuesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessValues>>> GetBusinessValues()
        {
            var result = await (from j in _context.BusinessValues
                                select new
                                {
                                    j.Id,
                                    j.Business,
                                    j.Rate
                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/BusinessValuesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessValues>> GetBusinessValues(long id)
        {
            var result = await (from j in _context.BusinessValues
                                where j.Id == id
                                select new
                                {
                                    j.Id,
                                    j.Business,
                                    j.Rate
                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/BusinessValuesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessValues(long id, BusinessValues businessValues)
        {
            if (id != businessValues.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessValues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessValuesExists(id))
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

        // POST: api/BusinessValuesAPI
        [HttpPost]
        public async Task<ActionResult<BusinessValues>> PostBusinessValues(BusinessValues businessValues)
        {
            _context.BusinessValues.Add(businessValues);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessValues", new { id = businessValues.Id }, businessValues);
        }

        // DELETE: api/BusinessValuesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessValues>> DeleteBusinessValues(long id)
        {
            var businessValues = await _context.BusinessValues.FindAsync(id);
            if (businessValues == null)
            {
                return NotFound();
            }

            _context.BusinessValues.Remove(businessValues);
            await _context.SaveChangesAsync();

            return businessValues;
        }

        private bool BusinessValuesExists(long id)
        {
            return _context.BusinessValues.Any(e => e.Id == id);
        }
    }
}
