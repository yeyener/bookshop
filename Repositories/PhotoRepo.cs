using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Repositories
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly BookDbContext context;
        public PhotoRepo(BookDbContext context)
        {
            this.context = context;

        }

        public void Add(BookInstPhoto photo)
        {
            this.context.Photos.Add(photo);
        }

        public async Task<IEnumerable<BookInstPhoto>> GetPhotosAsync(int vehicleId)
        {
            return await this.context.Photos.ToListAsync();
        }
    }
}