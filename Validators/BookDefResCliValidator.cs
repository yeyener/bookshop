using System.Linq;
using System.Threading.Tasks;
using bookshop.Repositories;
using bookshop.Resources;

namespace bookshop.Validators
{
    public class BookDefResCliValidator : IBookDefResCliValidator
    {
        private readonly IWriterRepo writerRepo;
        public BookDefResCliValidator(IWriterRepo writerRepo)
        {
            this.writerRepo = writerRepo;

        }

        public async Task<Result> IsValidAsync(BookDefResourceClient res)
        {
            var writers = await writerRepo.GetAll();
            if (!writers.Any(a => a.Id == res.WriterId))
                return Result.Fail("You must give a valid writer id to create a book definition");

            return Result.Succeed();
        }
    }
}