using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Writers")]
    public class Writer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [MinLength(3)]
        public string Name { get; set; }

        public string Definition { get; set; }

        public Country Country{get;set;}

        public int? CountryId{get;set;}
    }
}