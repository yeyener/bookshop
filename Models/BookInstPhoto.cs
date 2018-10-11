using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("BookInstPhotos")]
    public class BookInstPhoto 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        public BookInst BookInst{get;set;}

        public int BookInstId { get; set; }
    }
}