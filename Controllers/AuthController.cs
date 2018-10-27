using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bookshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace bookshop.Controllers
{
    [RouteAttribute("api/auth")]
    public class AuthController : Controller
    {

        [HttpPost("login")]
        public IActionResult Login([FromBody]User user)
        {
            if (user == null)
                return BadRequest("Invalid client request");
                
            if (user.Name == "YEY" && user.Password == "YEYPASS123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5001",
                    audience: "http://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
    
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody]User user){
            
            if (user == null)
                return BadRequest("Invalid client request");

            return Ok();
        }
    }
}