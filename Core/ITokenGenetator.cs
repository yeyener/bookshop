using bookshop.Models;

namespace bookshop.Core
{
    public interface ITokenGenetator
    {
         string Generate(User user);
    }
}