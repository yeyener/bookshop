using System.Collections.Generic;
using System.Threading.Tasks;
using bookshop.Models;

namespace bookshop.Repositories
{
    public interface IPhotoRepo
    {
        Task<IEnumerable<BookInstPhoto>> GetPhotosAsync(int bookInstId);

        void Add(BookInstPhoto photo);
    }
}