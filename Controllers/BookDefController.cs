using System.Collections.Generic;
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
        public BookDefController(IBookDefRepo repo, IMapper mapper, IBookDefResCliValidator cliValidator)
        {
            this.cliValidator = cliValidator;
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDef>> GetBookDefinitions()
        {
            return await this.repo.GetAll();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]BookDefResourceClient res)
        {
            Result isValid = await cliValidator.IsValidAsync(res);
            if (!isValid.Success)
                return BadRequest(isValid.ErrorMessage);
            
            var bookDef = this.mapper.Map<BookDefResourceClient, BookDef>(res);
            this.repo.Create(bookDef);

            return Ok();
        }
    }
}