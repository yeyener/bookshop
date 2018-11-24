using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class BookDefRepo : IBookDefRepo
    {
        private readonly BookDbContext context;

        public BookDefRepo(BookDbContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<BookDef>> GetAll()
        {
            return await context.BookDefinitons
                        .Include(b => b.Writer)
                        .Include(b => b.BookDefGenres)
                        .ToListAsync();;
        }


        public void Create(BookDef bookDef){
            context.BookDefinitons.Add(bookDef);
            context.SaveChanges();
        }

        public void Remove(BookDef bookDef){
            context.Remove(bookDef);
        }

        public void Add(BookDef bookDef){
            context.Add(bookDef);
        }
    }
}