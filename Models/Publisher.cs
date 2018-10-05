using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Publishers")]
    public class Publisher
    {
        public int Id { get; set; }

        public string  Name { get; set; }
    }
}