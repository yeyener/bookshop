using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Core;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Resources;
using bookshop.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace bookshop.Controllers
{
    [RouteAttribute("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepo userRepo;
        private readonly IUnitOfWork uow;
        private readonly ISignupValidator suValidator;
        private readonly IMapper mapper;
        private readonly ITokenGenetator tokenGenetator;

        public AuthController(IUserRepo userRepo, IUnitOfWork uow, ISignupValidator suValidator, IMapper mapper, ITokenGenetator tokenGenetator)
        {
            this.tokenGenetator = tokenGenetator;
            this.mapper = mapper;
            this.suValidator = suValidator;
            this.uow = uow;
            this.userRepo = userRepo;

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserResource userRsc)
        {
            if (userRsc == null)
                return BadRequest("Invalid client request");

            var dbUser = (await this.userRepo.GetAll()).FirstOrDefault(a => a.Name == userRsc.Name);
            if (dbUser == null)
                return BadRequest("Username not found:" + userRsc.Name);

            var userSalt = HashGenerator.StringToByteArray(dbUser.Salt);
            var hashPwd = HashGenerator.GenerateSaltedHash(HashGenerator.EncodedStringToByteArray(userRsc.Password), userSalt);
            if (HashGenerator.Compare(hashPwd, HashGenerator.StringToByteArray(dbUser.Password)))
                return Ok(new { Token = this.tokenGenetator.Generate(dbUser) });
            else
                return Unauthorized();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]UserResource userRsc)
        {
            if (userRsc == null)
                return BadRequest("Invalid request");

            var suValidation = await suValidator.IsValidAsync(userRsc);
            if (!suValidation.Success)
                return BadRequest(suValidation.ErrorMessage);

            User newUser = this.mapper.Map<UserResource, User>(userRsc);

            var salt = HashGenerator.GenerateSaltBytes();
            var hash = HashGenerator.GenerateSaltedHash(HashGenerator.EncodedStringToByteArray(userRsc.Password), salt);

            newUser.Salt = HashGenerator.ByteArrayToString(salt);
            newUser.Password = HashGenerator.ByteArrayToString(hash);

            userRepo.Create(newUser);
            uow.Complete();

            return Ok();
        }
    }
}