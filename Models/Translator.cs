using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Translators")]
    public class Translator
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}