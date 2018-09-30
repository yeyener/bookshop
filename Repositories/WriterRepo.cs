using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class WriterRepo : IWriterRepo
    {
        private readonly BookDbContext context;

        public WriterRepo(BookDbContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<Writer>> GetAll()
        {
            return await context.Writers.ToListAsync();
        }


        public void Create(Writer writer){
            context.Writers.Add(writer);
            context.SaveChanges();
        }
    }
}