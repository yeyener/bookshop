using System.Collections.Generic;
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

       public Publisher Publisher{get;set;}

       public int? PublisherId{get;set;}

       public Translator Translator{get;set;}

       public int? TranslatorId{get;set;}

       public Language Language{get;set;}

       public int? LanguageId { get; set; }

       public decimal Price{get;set;}

       public ICollection<BookInstPhoto> Photos;


       
    }
}