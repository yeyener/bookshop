using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace bookshop.Core
{
    public class TokenGenerator : ITokenGenetator
    {
        private readonly IConfiguration config;

        public TokenGenerator(IConfiguration config)
        {
            this.config = config;

        }
        public string Generate()
        {
            var a = config.GetSection("TokenKey").GetValue<string>("Default");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(a));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}