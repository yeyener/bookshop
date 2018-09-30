using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id{get;set;}

        public string Name { get; set; }
    }
}