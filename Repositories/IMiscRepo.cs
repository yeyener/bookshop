using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IMiscRepo
    {
         Task<IEnumerable<Language>> GetLanguages();

         Task<IEnumerable<Publisher>> GetPublishers();

         Task<IEnumerable<Translator>> GetTranslators();

         Task<IEnumerable<Genre>> GetGenres();
    }
}