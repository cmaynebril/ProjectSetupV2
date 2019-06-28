using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;
using ProjectSetupV2.Models.Softwares;

namespace ProjectSetupV2.Controllers.APIs.Softwares
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSoftwaresController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public UserSoftwaresController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/UserSoftwares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSoftware>>> GetUserSoftware()
        {
            var result = await (from a in _context.UserSoftware
                                select new
                                {
                                    a.Id,
                                    a.TimeStamp,
                                    RunningSoftwares = a.RunningSoftwares.Select(b => new {
                                        b.SoftwareId,
                                        b.Name,
                                        b.DateInstalled,
                                        b.Version
                                    })
                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/UserSoftwares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSoftware>> GetUserSoftware(int id)
        {
            var result = await (from a in _context.UserSoftware
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    a.TimeStamp,
                                    RunningSoftwares = a.RunningSoftwares.Select(b => new {
                                        b.SoftwareId,
                                        b.Name,
                                        b.DateInstalled,
                                        b.Version
                                    })
                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/UserSoftwares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSoftware(int id, UserSoftware userSoftware)
        {
            if (id != userSoftware.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSoftware).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSoftwareExists(id))
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

        // POST: api/UserSoftwares
        [HttpPost]
        public async Task<ActionResult> PostUserSoftware(UserSoftwareViewModel newuserSoftware)
        {
            if (ModelState.IsValid)
            {
                var userSoftware = new UserSoftware();
                userSoftware.TimeStamp = DateTime.Now;

                var a = _context.Add(userSoftware);
                await _context.SaveChangesAsync();

                var UserSoftwareId = _context.UserSoftware.OrderBy(x => x.Id).LastOrDefault();

                for (int i = 0; i < newuserSoftware.runningSoftwares.Count; i++)
                {
                    var runningSoftwares = new RunningSoftwares();
                    foreach (var item in newuserSoftware.runningSoftwares)
                    {
                        runningSoftwares.Name = item.name;
                        runningSoftwares.DateInstalled = item.dateInstalled;
                        runningSoftwares.Version = item.version;
                        runningSoftwares.MainSoftwareId = UserSoftwareId.Id;
                    }
                    var b = _context.Add(runningSoftwares);
                }

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUserSoftware", new { id = userSoftware.Id }, newuserSoftware);
            }
            return Ok();
        }

        // DELETE: api/UserSoftwares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSoftware>> DeleteUserSoftware(int id)
        {
            var userSoftware = await _context.UserSoftware.FindAsync(id);
            if (userSoftware == null)
            {
                return NotFound();
            }

            _context.UserSoftware.Remove(userSoftware);
            await _context.SaveChangesAsync();

            return userSoftware;
        }

        private bool UserSoftwareExists(int id)
        {
            return _context.UserSoftware.Any(e => e.Id == id);
        }
    }
}
