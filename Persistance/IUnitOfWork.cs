using System.Threading.Tasks;

namespace bookshop.Persistance
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}