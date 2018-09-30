using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("BookInsts")]
    public class BookInst
    {
       public int Id{get;set;} 

       public BookDef Definition{get;set;}

       public int DefinitionId { get; set; }

       public int NumberInStock{get;set;}

       public int PageNumber{get;set;}

       public int Edition { get; set; }

       public string BookName{get;set;} // Redundant

       public string WriterName{get;set;}  // Redundant
       
    }
}