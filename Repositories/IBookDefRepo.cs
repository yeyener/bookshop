using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IBookDefRepo
    {
        Task<IEnumerable<BookDef>> GetAll();
         
         void Create(BookDef bookDefinition);
    }
}