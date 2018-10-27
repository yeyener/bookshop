using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
    [RouteAttribute("api/writers/")]
    public class WriterController : Controller
    {
        private IWriterRepo repo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public WriterController(IWriterRepo repo, IMapper mapper, IUnitOfWork uow)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.repo = repo;

        }

        private void temp()
        {

        }



        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var writers = await this.repo.GetAll();

            return Ok(writers);
        }

        [HttpGet("getAllNames")]
        public async Task<IActionResult> GetAllNames()
        {
            var writers = await this.repo.GetAll();
            // Dictionary<int,string> names = new Dictionary<int, string>();

            // foreach (Writer w in writers)
            //     names.Add(w.Id, w.Name);

            List<string> names = new List<string>();
            foreach (Writer w in writers)
                names.Add(w.Name);

            return Ok(names);
        }

        [HttpGet("getAllNamesAndIds")]
        public async Task<IActionResult> GetAllNamesAndIds()
        {
            var writers = await this.repo.GetAll();
            Dictionary<int, string> names = new Dictionary<int, string>();

            foreach (Writer w in writers)
                names.Add(w.Id, w.Name);

            // List<string> names = new List<string>();
            // foreach (Writer w in writers)
            //      names.Add(w.Name);

            return Ok(names);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]WriterResourceClient writerRes)
        {
            var toUpdate = await getWriter(id);
            if (toUpdate == null)
                return BadRequest("No writer found with the id : " + id);

            Writer newWriter = mapper.Map<WriterResourceClient, Writer>(writerRes);

            toUpdate.Name = newWriter.Name;
            toUpdate.Definition = newWriter.Definition;

            await uow.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var toDelete = await getWriter(id);
            if (toDelete == null)
                return BadRequest("No writer found with the id : " + id);

            repo.Delete(toDelete);
            return Ok();
        }

        private async Task<Writer> getWriter(int id)
        {
            var writers = await repo.GetAll();
            Writer writer = writers.FirstOrDefault(w => w.Id == id);
            return writer;
        }
    }
}