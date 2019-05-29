﻿using System;
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
    public class ClientsAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public ClientsAPIController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/ClientsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
        {
            var result = await (from c in _context.Clients
                                select new
                                {
                                    c.Id,
                                    c.Client,
                                }).ToListAsync();

            return Ok(result);
        }

        // GET: api/ClientsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clients>> GetClients(long id)
        {
            var result = await (from c in _context.Clients
                                where c.Id == id
                                select new
                                {
                                    c.Id,
                                    c.Client,
                                })
                              .SingleOrDefaultAsync();

            return Ok(result);
        }

        // PUT: api/ClientsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients(long id, Clients clients)
        {
            if (id != clients.Id)
            {
                return BadRequest();
            }

            _context.Entry(clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: api/ClientsAPI
        [HttpPost]
        public async Task<ActionResult<Clients>> PostClients(Clients clients)
        {
            _context.Clients.Add(clients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClients", new { id = clients.Id }, clients);
        }

        // DELETE: api/ClientsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clients>> DeleteClients(long id)
        {
            var clients = await _context.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clients);
            await _context.SaveChangesAsync();

            return clients;
        }

        private bool ClientsExists(long id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
