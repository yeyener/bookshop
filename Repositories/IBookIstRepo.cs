using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.QueryObjects;

namespace bookshop.Repositories
{
    public interface IBookInstRepo
    {
          Task<IEnumerable<BookInst>> GetAll();

          Task<BookInst> Get(int bookInstanceId);

          Task<IEnumerable<BookInst>> GetAllByWriterId(int writerId);

          Task<IEnumerable<BookInst>> GetAllByWriterNameLike(string writerNameLike);

          Task<IEnumerable<BookInst>> GetAllByCustom(BookInstQueryObject queryObject);
          void Create(BookInst bookInst);
    }
}