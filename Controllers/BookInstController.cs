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
        private readonly IBookDefRepo definitionRepo;
        private readonly IUnitOfWork uow;

        public BookInstController(IBookInstRepo repo, IMapper mapper, IBookInstResourceClientValidator resourceClientValidator, IBookDefRepo definitionRepo, IUnitOfWork uow)
        {
            this.uow = uow;
            this.definitionRepo = definitionRepo;
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
            var instResAsLists =  lists<BookInstResource>(instResource, 4);
            return Ok(instResAsLists);
        }

        private IEnumerable<IEnumerable<T>> lists<T>(IEnumerable<T> items, int itemInEachSubList){
            List<List<T>> list = new List<List<T>>();

            int index = 0;
            foreach(T item in items){
                if (index++ % itemInEachSubList == 0){
                    list.Add(new List<T>());
                }
                list.LastOrDefault().Add(item);
            }
            return list;
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
        public async Task<IActionResult> Create([FromBody]BookInstResource bookInstRes)
        {
            var valResult = await resourceClientValidator.IsValidAsync(bookInstRes);
            if (!valResult.Success)
                return BadRequest(valResult.ErrorMessage);

            // Redundant alanları set edelim tanımlardan
            var bookInst = mapper.Map<BookInstResource, BookInst>(bookInstRes);
            var defs = await definitionRepo.GetAll();
            bookInst.WriterName = defs.FirstOrDefault(a => a.Id == bookInst.DefinitionId).Writer.Name;
            bookInst.BookName = defs.FirstOrDefault(a => a.Id == bookInst.DefinitionId).Name;

            repo.Create(bookInst);

            var bookInsts = await this.repo.GetAll();
            var justCreated = bookInsts.Where(a => a.Definition.Name == bookInst.Definition.Name);
            return Ok(justCreated);
        }


        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]BookInstResource bookInstRes)
        {
            var valResult = await resourceClientValidator.IsValidAsync(bookInstRes);
            if (!valResult.Success)
                return BadRequest(valResult.ErrorMessage);
            
            var toUpdate = await getBookInst(bookInstRes.Id);
            if (toUpdate == null)
                return BadRequest("No book instance found with the id : " + bookInstRes.Id);

            var bookInst = mapper.Map<BookInstResource, BookInst>(bookInstRes);
            updateFields(toUpdate,bookInst);

            await uow.CompleteAsync();

            var justUpdated = await this.repo.Get(bookInstRes.Id);            
            return Ok(justUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var toDelete = await getBookInst(id);
            if (toDelete == null)
                return BadRequest("No book instance found with the id : " + id);

            repo.Delete(toDelete);
            uow.Complete();
            return Ok();
        }

        private void updateFields(BookInst target, BookInst source){
            target.PublisherId = source.PublisherId;
            target.Edition = source.Edition;
            target.Price = source.Price;
            target.LanguageId = source.LanguageId;
            target.NumberInStock = source.NumberInStock;
            target.PageNumber = source.PageNumber;

            return;
        }

        private async Task<BookInst> getBookInst(int id){
            var insts = await this.repo.GetAll();
            var b = insts.FirstOrDefault(o => o.Id == id);
            return b;
        }

        private IEnumerable<BookInstResource> mapList(IEnumerable<BookInst> list)
        {
            return mapper.Map<IEnumerable<BookInst>, IEnumerable<BookInstResource>>(list);
        }




    }
}