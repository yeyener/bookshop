using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IPhotoRepo
    {
        Task<IEnumerable<BookInstPhoto>> GetPhotos(int vehicleId);

         void Add(BookInstPhoto photo);
    }
}