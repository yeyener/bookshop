using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class BookInstRepo : IBookInstRepo
    {
        private readonly BookDbContext context;
        public BookInstRepo(BookDbContext context)
        {
            this.context = context;

        }

        public async Task<BookInst> Get(int bookInstanceId){
            return await context.BookInstances.FirstOrDefaultAsync(a => a.Id == bookInstanceId);
        }

        public async Task<IEnumerable<BookInst>> GetAll(){
            return await context.BookInstances
                        .Include(bi => bi.Definition).ToListAsync();
        }

        public async Task<IEnumerable<BookInst>> GetAllByWriterId(int writerId){
            var booksQuery = context.BookInstances
            .Include(bi => bi.Definition)
            .ThenInclude(bd => bd.Writer)            
            .AsQueryable();

            booksQuery = booksQuery.Where(a => a.Definition.Writer.Id == writerId);

            return await booksQuery.ToListAsync();            
        }

        public async Task<IEnumerable<BookInst>> GetAllByWriterNameLike(string writerNameLike){
            var booksQuery = context.BookInstances
            .Include(bi => bi.Definition)
                .ThenInclude(bd => bd.Writer)
            .AsQueryable();

            booksQuery = booksQuery.Where(a => a.Definition.Writer.Name.Contains(writerNameLike));

            return await booksQuery.ToListAsync();
        }

        public async Task<IEnumerable<BookInst>> GetAllByCustom(BookInstQueryObject queryObject){
            var booksQuery = context.BookInstances            
            .Include(bi => bi.Definition)                
                .ThenInclude(bd => bd.Writer)
             .Include(bi => bi.Definition)
                 .ThenInclude(bd => bd.BookDefGenres).ThenInclude(g => g.Genre)
             .Include(bi => bi.Language)
             .Include(bi => bi.Translator)
             .Include(bi => bi.Publisher)
             .AsQueryable();

            booksQuery = filterQuery(booksQuery, queryObject);

            return await booksQuery.ToListAsync();
        }

        public void Create(BookInst bookInst){
            context.BookInstances.Add(bookInst);
            context.SaveChanges();
        }

        public void Delete(BookInst bookInst){
            context.BookInstances.Remove(bookInst);
        }

        private IQueryable<BookInst> filterQuery(IQueryable<BookInst> queryableSet, BookInstQueryObject queryObject){
            if (!string.IsNullOrWhiteSpace(queryObject.WriterNameLike))
                queryableSet = queryableSet.Where(a => a.Definition.Writer.Name.Contains(queryObject.WriterNameLike));

            if (!string.IsNullOrWhiteSpace(queryObject.GenreNameLike))
                queryableSet = queryableSet.Where(q => q.Definition.BookDefGenres.Any(gg => gg.Genre.Name.Contains(queryObject.GenreNameLike)));
            
            if (queryObject.WriterId > 0 )
                queryableSet = queryableSet.Where(a => a.Definition.Writer.Id == queryObject.WriterId);                                            
        
        return queryableSet;
        }
    }
}