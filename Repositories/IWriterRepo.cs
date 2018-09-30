using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IWriterRepo
    {
         Task<IEnumerable<Writer>> GetAll();
         
         void Create(Writer writer);
         
    }
}