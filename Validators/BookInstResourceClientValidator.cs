using System.Linq;
using System.Threading.Tasks;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Resources;

namespace bookshop.Validators
{
    public class BookInstResourceClientValidator : IBookInstResourceClientValidator
    {
        private readonly IBookDefRepo bookDefRepo;
        private readonly IMiscRepo miscRepo;
        public BookInstResourceClientValidator(IBookDefRepo bookDefRepo, IMiscRepo miscRepo)
        {
            this.miscRepo = miscRepo;
            this.bookDefRepo = bookDefRepo;
        }

        public async Task<Result> IsValidAsync(BookInstResourceClient res)
        {

            var writers = await this.bookDefRepo.GetAll();
            if (!writers.Any(w => w.Id == res.DefinitionId))
                return Result.Fail("The instance of a book must have valid definition id");

            if (res.LanguageId.HasValue){
                var langs = await miscRepo.GetLanguages();
                if (!langs.Any(l => l.Id == res.LanguageId))
                    return Result.Fail("Invalid LanguageId. You must provide a valid LanguageId or no LanguageId (null)");
            }

            if (res.PublisherId.HasValue){
                var pubs = await miscRepo.GetPublishers();
                if (!pubs.Any(l => l.Id == res.PublisherId))
                    return Result.Fail("Invalid PublisherId. You must provide a valid PublisherId or no PublisherId (null)");
            }

            if (res.TranslatorId.HasValue){
                var trns = await miscRepo.GetTranslators();
                if (!trns.Any(l => l.Id == res.TranslatorId))
                    return Result.Fail("Invalid TranslatorId. You must provide a valid TranslatorId or no TranslatorId (null)");
            }

            return Result.Succeed();
        }

    }
}