using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Resources;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
    [RouteAttribute("api/writers")]
    public class WriterController : Controller
    {
        private IWriterRepo repo;
        private readonly IMapper mapper;
        private readonly BookDbContext context;

        public WriterController(IWriterRepo repo, IMapper mapper, BookDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
            this.repo = repo;

        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var writers = await this.repo.GetAll();

            return Ok(writers);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]WriterResourceClient writerRes)
        {
            var writer = mapper.Map<WriterResourceClient, Writer>(writerRes);
            repo.Create(writer);

            //context.SaveChangesAsync();

            var writers = await this.repo.GetAll();
            var justCreated = writers.Where(a => a.Name == writerRes.Name);
            return Ok(justCreated);
        }
    }
}