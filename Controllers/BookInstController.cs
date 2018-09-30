using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.QueryObjects;
using bookshop.QueryObjects.Resources;
using bookshop.Repositories;
using bookshop.Resources;
using bookshop.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Controllers
{
    [RouteAttribute("api/bookInstances/")]
    public class BookInstController : Controller
    {
        private readonly IBookInstRepo repo;
        private readonly IMapper mapper;

        private readonly IBookInstResourceClientValidator resourceClientValidator;

        public BookInstController(IBookInstRepo repo, IMapper mapper, IBookInstResourceClientValidator resourceClientValidator)
        {
            this.resourceClientValidator = resourceClientValidator;
            this.mapper = mapper;
            this.repo = repo;
        }


        [HttpGet("{bookInstanceId}")]
        public async Task<IActionResult> GetBookInstance(int bookInstanceId)
        {
            var book = await repo.Get(bookInstanceId);
            if (book == null)
                return NotFound();

            var instResource = mapper.Map<BookInst, BookInstResource>(book);

            return Ok(instResource);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var book = await repo.GetAll();
            if (book == null)
                return NotFound();

            var instResource = mapper.Map<IEnumerable<BookInst>, IEnumerable<BookInstResource>>(book);

            return Ok(instResource);
        }


        [HttpGet("getByCustom")]
        public async Task<IActionResult> GetByCustom(BookInstQueryObjectResource queryObjectRes)
        {
            var queryObject = Mapper.Map<BookInstQueryObjectResource, BookInstQueryObject>(queryObjectRes);

            var books = await repo.GetAllByCustom(queryObject);
            if (books == null)
                return NotFound();

            //return Ok(books);
            return Ok(mapList(books));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]BookInstResourceClient bookInstRes)
        {
            var valResult = await resourceClientValidator.IsValidAsync(bookInstRes);
            if (!valResult.Success)
                return BadRequest(valResult.ErrorMessage);

            var bookInst = mapper.Map<BookInstResourceClient, BookInst>(bookInstRes);
            repo.Create(bookInst);

            var bookInsts = await this.repo.GetAll();
            var justCreated = bookInsts.Where(a => a.Definition.Name == bookInst.Definition.Name);
            return Ok(justCreated);
        }

        private IEnumerable<BookInstResource> mapList(IEnumerable<BookInst> list)
        {
            return mapper.Map<IEnumerable<BookInst>, IEnumerable<BookInstResource>>(list);
        }




    }
}