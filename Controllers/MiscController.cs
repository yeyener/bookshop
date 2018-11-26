using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
    [RouteAttribute("api/misc")]
    public class MiscController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMiscRepo repo;
        public MiscController(IMiscRepo repo, IUnitOfWork uow)
        {
            this.repo = repo;
            this.uow = uow;

        }

        [HttpGet("getPublishers")]
        public async Task<IActionResult> GetPublishers(){
            IDictionary<int,string> kvps = new Dictionary<int, string>();
            foreach (var p in await this.repo.GetPublishers())
                kvps.Add(p.Id, p.Name);
            return Ok(kvps);
        }

        [HttpGet("getTranslators")]
        public async Task<IActionResult> GetTranslators(){
            IDictionary<int,string> kvps = new Dictionary<int, string>();
            foreach (var p in await this.repo.GetTranslators())
                kvps.Add(p.Id, p.Name);
            return Ok(kvps);
        }

        [HttpGet("getLanguages")]
        public async Task<IActionResult> GetLanguages(){
            IDictionary<int,string> kvps = new Dictionary<int, string>();
            foreach (var p in await this.repo.GetLanguages())
                kvps.Add(p.Id, p.Name);
            return Ok(kvps);
        }

        [HttpGet("getGenres")]
        public async Task<IActionResult> GetGenres(){
            IDictionary<int,string> kvps = new Dictionary<int, string>();
            foreach (var p in await this.repo.GetGenres())
                kvps.Add(p.Id, p.Name);
            return Ok(kvps);
        }
    }
}