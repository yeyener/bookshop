using System.Threading.Tasks;
using bookshop.Resources;

namespace bookshop.Validators
{
    public interface IBookInstResourceClientValidator
    {
          Task<Result> IsValidAsync(BookInstResourceClient res);
    }
}