using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Resources;
using bookshop.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Controllers
{
    [RouteAttribute("api/bookDefinitions")]
    public class BookDefController : Controller
    {
        private readonly IBookDefRepo repo;
        private readonly IMiscRepo miscRepo;
        private readonly IMapper mapper;
        private readonly IBookDefResCliValidator cliValidator;
        private readonly IUnitOfWork uow;
        public BookDefController(IBookDefRepo repo, IMapper mapper, IBookDefResCliValidator cliValidator, IUnitOfWork uow, IMiscRepo miscRepo)
        {
            this.miscRepo = miscRepo;
            this.uow = uow;
            this.cliValidator = cliValidator;
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDefResource>> GetBookDefinitions()
        {
            var bookDefs = await this.repo.GetAll();
            return Mapper.Map<IEnumerable<BookDef>, IEnumerable<BookDefResource>>(bookDefs);
        }

         [HttpGet("getNames")]
        public async Task<Dictionary<int, string>> GetNames()
        {
            Dictionary<int, string> names = new Dictionary<int, string>();
            var bookDefs = await this.repo.GetAll();
            foreach (var bookdef in bookDefs){
                if (!names.ContainsValue(bookdef.Name))
                    names.Add( bookdef.Id, bookdef.Name);
            }
            return names;
        }

        [HttpGet("getWritersBookDefs")]
        public async Task<IEnumerable<BookDefResource>> GetBooksByWriter(int writerId)
        {
            var bookDefs = await this.repo.GetAll();
            bookDefs = bookDefs.Where(bd => bd.WriterId == writerId);
            var retVal = Mapper.Map<IEnumerable<BookDef>, IEnumerable<BookDefResource>>(bookDefs);
            return retVal;
        }
        [HttpGet("getWritersBookDefsAsKvps")]
        public async Task<IActionResult> GetBooksByWriterAsKvps(int writerId)
        {
            var bookDefs = await this.repo.GetAll();
            bookDefs = bookDefs.Where(bd => bd.WriterId == writerId);

            IDictionary<int, string> kvps = new Dictionary<int, string>();
            foreach (var bookDef in bookDefs)
                kvps.Add(bookDef.Id, bookDef.Name);

            return Ok(kvps);
        }



        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]BookDefResourceClient res)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Result isValid = await cliValidator.IsValidAsync(res);
            if (!isValid.Success)
                return BadRequest(isValid.ErrorMessage);

            var bookDef = this.mapper.Map<BookDefResourceClient, BookDef>(res);
            this.repo.Create(bookDef);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]BookDefResourceClient res)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var toUpdate = await getBookDef(id);
            var bookDef = this.mapper.Map<BookDefResourceClient, BookDef>(res);

            toUpdate.Name = bookDef.Name;
            toUpdate.YearWritten = bookDef.YearWritten;

            toUpdate = bookDef;

            await uow.CompleteAsync();

            return Ok();
        }

        [HttpPatch("updateGenres/{id}")]
        public async Task<IActionResult> UpdateGenres(int id, [FromBody]List<int> genreIds)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var toUpdate = await getBookDef(id);
            toUpdate.BookDefGenres = await convert(genreIds, toUpdate);

            await uow.CompleteAsync();

            return Ok();
        }

        private async Task<Collection<BookDefGenre>> convert(IEnumerable<int> genreIDs, BookDef bookDef)
        {
            var genres = await this.miscRepo.GetGenres();
            Collection<BookDefGenre> retVal = new Collection<BookDefGenre>();
            foreach (var genreId in genreIDs)
            {
                retVal.Add(new BookDefGenre() { BookDef = bookDef, BookDefId = bookDef.Id, Genre = genres.FirstOrDefault(a => a.Id == genreId), GenreId = genreId });
            }

            return retVal;
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Result isValid = await cliValidator.IsValidAsync(res);
            // if (!isValid.Success)
            //     return BadRequest(isValid.ErrorMessage);

            var toDelete = await getBookDef(id);
            this.repo.Remove(toDelete);


            await uow.CompleteAsync();

            return Ok();
        }




        private async Task<BookDef> getBookDef(int id)
        {
            var all = await this.repo.GetAll();
            return all.FirstOrDefault(a => a.Id == id);
        }
    }
}