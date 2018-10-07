using System.Collections.Generic;
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
        private readonly IMapper mapper;
        private readonly IBookDefResCliValidator cliValidator;        
        private readonly IUnitOfWork uow;
        public BookDefController(IBookDefRepo repo, IMapper mapper, IBookDefResCliValidator cliValidator, IUnitOfWork uow)
        {
            this.uow = uow;            
            this.cliValidator = cliValidator;
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDef>> GetBookDefinitions()
        {
            return await this.repo.GetAll();
        }

        [HttpGet("getWritersBookDefs")]
        public async Task<IEnumerable<BookDefResource>> GetBooksByWriter(int writerId)
        {
            var bookDefs = await this.repo.GetAll();
            bookDefs = bookDefs.Where(bd => bd.WriterId == writerId);
            var retVal = Mapper.Map<IEnumerable<BookDef>, IEnumerable<BookDefResource>>(bookDefs);
            return retVal;
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