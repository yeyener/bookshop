using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Repositories;
using bookshop.Resources;

namespace bookshop.Validators
{
    public class SignupValidator : ISignupValidator
    {
        private readonly IUserRepo userRepo;

        public SignupValidator(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<Result> IsValidAsync(UserResource res)
        {
            var users = await this.userRepo.GetAll();
            if (users.Any( a => a.Name == res.Name))
                return Result.Fail("Username " + res.Name + " is already taken. Please pick a new username");


            
            return Result.Succeed();
        }
    }
}