using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers.APIs
{
    [Route("api/user")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly DBProjectSetupContext _context;
        private readonly UserManager<User> _userManager;

        public UserAPIController(DBProjectSetupContext context, UserManager<User> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/UserAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await (from a in _userManager.Users
                                select new
                                {
                                   a.Id,
                                   a.UserName,
                                   a.Position,
                                   a.Department,
                                   a.Section,
                                   a.Email,
                                   a.TeamLeaderId,
                                   a.SupervisorId,
                                   a.ManagerId,

                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/UserAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await (from a in _userManager.Users
                                where (a.Id == id)
                                select new
                                {
                                    a.Id,
                                    a.UserName,
                                    a.Email
                                }).ToListAsync();
            return Ok(result);
        }
    }
}
