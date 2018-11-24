using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly BookDbContext context;

        public UserRepo(BookDbContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.Include(u => u.UserCustomClaims).ThenInclude(cc => cc.CustomClaim)
                        .ToListAsync();
        }

        public void Create(User user){
            context.Users.Add(user);
            context.SaveChanges();
        }
        
        public async void Delete(User toDelete){
            context.Users.Remove(toDelete);
            await context.SaveChangesAsync();
        }
    }
}