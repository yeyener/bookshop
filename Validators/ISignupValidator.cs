using System.Threading.Tasks;
using bookshop.Models;
using bookshop.Resources;

namespace bookshop.Validators
{
    public interface ISignupValidator
    {
         Task<Result> IsValidAsync(UserResource res);
    }
}