using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bookshop.Models;
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
        public string Generate(User user)
        {
            var a = config.GetSection("TokenKey").GetValue<string>("Default");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(a));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: getUsersClaims(user.UserCustomClaims),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        private List<Claim> getUsersClaims(Collection<UserCustomClaim> customClaims ){
            List<Claim> retVal = new List<Claim>();

            foreach (var customClaim in customClaims){
                retVal.Add(new Claim(customClaim.CustomClaim.Type,customClaim.CustomClaim.Name));
            }
            return retVal;
        }

    }
}