using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAll();
         
         void Create(User user);

         void Delete(User userId);
    }
}