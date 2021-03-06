using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
namespace bookshop.Controllers
{
    // 
    [Route("/api/bookInstPhotos/{bookInstId}/")]
    public class PhotosController : Controller
    {
        public static readonly string UploadFolderName =  Startup.StaticConfigYey.GetSection("PhotoSettings").GetValue<string>("UploadFolder");
        private readonly IHostingEnvironment host;
        private readonly IBookInstRepo bookInstRepo;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;
        private readonly IOptionsSnapshot<PhotoSettings> options;
        private readonly IPhotoRepo photoRepo;
        public PhotosController(IHostingEnvironment host, IBookInstRepo repo, IUnitOfWork uow, IMapper mapper, IOptionsSnapshot<PhotoSettings> options, IPhotoRepo photoRepo, IConfiguration config)
        {
            this.photoRepo = photoRepo;
            this.photoSettings = options.Value;
            this.mapper = mapper;
            this.uow = uow;
            this.bookInstRepo = repo;
            this.host = host;            
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int bookInstId)
        {
            var photos = await this.photoRepo.GetPhotosAsync(bookInstId);
            var retVal = photos.Where( a => a.BookInstId == bookInstId);
            return Mapper.Map<IEnumerable<BookInstPhoto>,IEnumerable<PhotoResource>>(retVal );
        }


        [HttpPost]
        public async Task<IActionResult> Upload(int bookInstId, IFormFile file)
        { // IFormCollection

            var bookInst = await bookInstRepo.Get(bookInstId);

            if (bookInst == null)
                return NotFound();

            if (file == null) { return BadRequest("Null file"); }

            if (file.Length == 0) { return BadRequest("Empty file"); }

            if (file.Length > photoSettings.MaxBytes) { return BadRequest("You exceeded allowed maximum size ("+ photoSettings.MaxBytes + " bytes)"); }

            if (!photoSettings.AcceptedFileTypes.Any(s => s == Path.GetExtension(file.FileName).ToLower())) { return BadRequest("Unaccepted file type. Accepted file types are :" + string.Join(" , " , photoSettings.AcceptedFileTypes));}

            var uploadFolderPath = Path.Combine(host.WebRootPath, UploadFolderName);

            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new BookInstPhoto() { FileName = fileName,  BookInstId = bookInst.Id, BookInst = bookInst };
            bookInst.Photos.Add(photo);
            photoRepo.Add(photo);

            await uow.CompleteAsync();

            return Ok(mapper.Map<BookInstPhoto, PhotoResource>(photo));
            // System.Drawing
        }

        public class PhotoResource
        {
            public string FileName{get;set;}

            public int BookInstId{get;set;}
        }
    }
}