using System.Threading.Tasks;

namespace bookshop.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext context;
        public UnitOfWork(BookDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Complete(){
            this.context.SaveChanges();
        }
    }
}