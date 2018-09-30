using System.Threading.Tasks;
using bookshop.Resources;

namespace bookshop.Validators
{
    public interface IBookDefResCliValidator
    {
         Task<Result> IsValidAsync(BookDefResourceClient res);
    }
}