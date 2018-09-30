using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Genres")]
    public class Genre
    {
        public int Id{get;set;}
        public string Name{get;set;}
        
              
    }
}