using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class MiscRepo : IMiscRepo
    {
        private readonly BookDbContext context;
        public MiscRepo(BookDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return await context.Languages.ToListAsync();
        }

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return await context.Publishers.ToListAsync();
        }

        public async Task<IEnumerable<Translator>> GetTranslators()
        {
            return await context.Translators.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await context.Genres.ToListAsync();
        }
    }
}