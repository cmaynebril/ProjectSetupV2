using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore.Jwt;
using ProjectSetupV2.Models;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers.APIs
{

    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly DBProjectSetupContext _context;

        public TokenController(DBProjectSetupContext context, SignInManager<User> signInManager) // you selected the "property" option. the next option was for field. 
            // this will work too
        {
            _context = context;
            SignInManager = signInManager;
            // you can generate this part. ctrl + .
        }

        public SignInManager<User> SignInManager { get; }

        [Authorize(AuthenticationSchemes = NetCoreJwtDefaults.SchemeName), HttpGet]
        public string Get() => "Entered as " + User.Identity.Name;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Token token)
        {
            var userManager = SignInManager.UserManager;
            var foundUser = userManager.Users.SingleOrDefault(u => u.UserName == token.UserName);
            if (foundUser == null) return BadRequest();

            // this function only checks the password. doesn't try to log you in with cookie
            var res = await SignInManager.CheckPasswordSignInAsync(foundUser, token.Password, false);
            if (res.Succeeded)
            {
                var claims = await userManager.GetClaimsAsync(foundUser); // claims will contain all data related to the user that normally goes in the login
                return Ok(HttpContext.GenerateBearerToken(claims));
            }
            return BadRequest();
            //var result = await SignInManager.PasswordSignInAsync(token.UserName, token.Password, false, false); // set last to true to lock
            //if (result.Succeeded)
            //{

            //    return Ok(HttpContext.GenerateBearerToken(token.UserName));
            //}
            //else return BadRequest();
            // var userManager = SignInManager.UserManager.CreateAsync(); // if you need to create a new user
            //var dbUser = _context.Users.Where(x => x.UserName == token.UserName && x.PasswordHash == token.Password).ToList();
            //if (dbUser.Count == 1)
            //{
            //    return Ok(HttpContext.GenerateBearerToken(token.UserName));
            //}

            //if (token.Password == "")
            //{
            //    return Ok(HttpContext.GenerateBearerToken(token.UserName));
            //}
            //return BadRequest();
        }

        //public interface IPasswordHasher<Token> where Token : class
        //{
        //    string HashPassword(Token token, string password);
        //}
    }
}