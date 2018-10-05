using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Languages")]
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}