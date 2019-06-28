using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;
using ProjectSetupV2.Models.Hardwares;

namespace ProjectSetupV2.Controllers.APIs.Hardwares
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHardwaresController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;

        public UserHardwaresController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: api/UserHardwares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHardware>>> GetUserHardware()
        {
            var result = await (from a in _context.UserHardware
                                select new
                                {
                                    a.Id,
                                    a.TimeStamp,
                                    Disks = a.Disk.Select(b => new {
                                        b.DiskId,
                                        b.Name,
                                        b.Type,
                                        b.SerialNumber,
                                        b.Title,
                                        b.Spec,
                                    }),
                                    Displays = a.Display.Select(b => new {
                                        b.DisplayId,
                                        b.Name,
                                        b.Type,
                                        b.SerialNumber,
                                        b.Manufacturer,
                                    }),
                                    UsbDevices = a.UsbDevice.Select(b => new {
                                        b.UsbDeviceId,
                                        b.Name,
                                        b.Description,
                                    })

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/UserHardwares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHardware>> GetUserHardware(int id)
        {
            var result = await (from a in _context.UserHardware
                                where a.Id == id
                                select new
                                {
                                    a.Id,
                                    a.TimeStamp,
                                    Disks = a.Disk.Select(b => new {
                                        b.DiskId,
                                        b.Name,
                                        b.Type,
                                        b.SerialNumber,
                                        b.Title,
                                        b.Spec,
                                    }),
                                    Displays = a.Display.Select(b => new {
                                        b.DisplayId,
                                        b.Name,
                                        b.Type,
                                        b.SerialNumber,
                                        b.Manufacturer,
                                    }),
                                    UsbDevices = a.UsbDevice.Select(b => new {
                                        b.UsbDeviceId,
                                        b.Name,
                                        b.Description,
                                    })

                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/UserHardwares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHardware(int id, UserHardware userHardware)
        {
            if (id != userHardware.Id)
            {
                return BadRequest();
            }

            _context.Entry(userHardware).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHardwareExists(id))
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

        // POST: api/UserHardwares
        [HttpPost]
        public async Task<ActionResult> PostUserHardware(UserHardwareViewModel newuserHardware)
        {
            if (ModelState.IsValid)
            {
                var userHardware = new UserHardware();
                userHardware.TimeStamp = DateTime.Now;

                var a = _context.Add(userHardware);
                await _context.SaveChangesAsync();
                var UserHardwareId = _context.UserHardware.OrderBy(x => x.Id).LastOrDefault();

                for (int i = 0; i < newuserHardware.disks.Count ; i++)
                {
                    var disks = new Disk();
                    foreach (var item in newuserHardware.disks)
                    {
                        disks.Name = item.name;
                        disks.Type = item.type;
                        disks.SerialNumber = item.serialNumber;
                        disks.Title = item.title;
                        disks.Spec = item.spec;
                        disks.UserHardwareId = UserHardwareId.Id;
                    }
                    var b = _context.Add(disks);
                }

                for (int i = 0; i < newuserHardware.displays.Count; i++)
                {
                    var displays = new Display();
                    foreach (var item in newuserHardware.displays)
                    {
                        displays.Name = item.name;
                        displays.Type = item.type;
                        displays.SerialNumber = item.serialNumber;
                        displays.Manufacturer = item.manufacturer;
                        displays.UserHardwareId = UserHardwareId.Id;
                    }
                    var c = _context.Add(displays);
                }

                for (int i = 0; i < newuserHardware.usbDevices.Count; i++)
                {
                    var usbDevices = new UsbDevice();
                    foreach (var item in newuserHardware.usbDevices)
                    {
                        usbDevices.Name = item.name;
                        usbDevices.Description = item.description;
                        usbDevices.UserHardwareId = UserHardwareId.Id;
                    }
                    var d = _context.Add(usbDevices);
                }

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUserHardware", new { id = userHardware.Id }, newuserHardware);

            }
            return Ok();

           
        }

        // DELETE: api/UserHardwares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserHardware>> DeleteUserHardware(int id)
        {
            var userHardware = await _context.UserHardware.FindAsync(id);
            if (userHardware == null)
            {
                return NotFound();
            }

            _context.UserHardware.Remove(userHardware);
            await _context.SaveChangesAsync();

            return userHardware;
        }

        private bool UserHardwareExists(int id)
        {
            return _context.UserHardware.Any(e => e.Id == id);
        }
    }
}
