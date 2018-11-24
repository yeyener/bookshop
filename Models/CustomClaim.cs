using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("CustomClaims")]
    public class CustomClaim
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }
    }
}