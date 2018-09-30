using System.Linq;
using System.Threading.Tasks;
using bookshop.Repositories;
using bookshop.Resources;

namespace bookshop.Validators
{
    public class BookInstResourceClientValidator : IBookInstResourceClientValidator
    {
        private readonly IBookDefRepo bookDefRepo;
        public BookInstResourceClientValidator(IBookDefRepo bookDefRepo)
        {
            this.bookDefRepo = bookDefRepo;
        }

        public async Task<Result> IsValidAsync(BookInstResourceClient res){

            var writers = await this.bookDefRepo.GetAll();
            if (!writers.Any( w => w.Id == res.DefinitionId))
                return Result.Fail("The instance of a book must have valid definition id");
            
            return Result.Succeed();
        }
    }
}