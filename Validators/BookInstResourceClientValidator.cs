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

        public async Task<Result> IsValidAsync(BookInstResource res)
        {

            var writers = await this.bookDefRepo.GetAll();
            if (!writers.Any(w => w.Id == res.DefinitionId))
                return Result.Fail("The instance of a book must have valid definition id");

            if (res.LanguageId.HasValue && res.LanguageId > 0 ){
                var langs = await miscRepo.GetLanguages();
                if (!langs.Any(l => l.Id == res.LanguageId))
                    return Result.Fail("Invalid LanguageId. You must provide a valid LanguageId or no LanguageId (zero)");
            }

            if (res.PublisherId.HasValue && res.PublisherId > 0){
                var pubs = await miscRepo.GetPublishers();
                if (!pubs.Any(l => l.Id == res.PublisherId))
                    return Result.Fail("Invalid PublisherId. You must provide a valid PublisherId or no PublisherId (zero)");
            }

            if (res.TranslatorId.HasValue && res.TranslatorId > 0){
                var trns = await miscRepo.GetTranslators();
                if (!trns.Any(l => l.Id == res.TranslatorId))
                    return Result.Fail("Invalid TranslatorId. You must provide a valid TranslatorId or no TranslatorId (zero)");
            }

            return Result.Succeed();
        }

    }
}