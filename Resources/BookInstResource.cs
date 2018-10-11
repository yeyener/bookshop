using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bookshop.Resources
{
    public class BookInstResource
    {
       public int Id{get;set;} 
       
       public int NumberInStock{get;set;}

       public int PageNumber{get;set;}

       public int Edition { get; set; }

       public string BookName{get;set;} // Redundant

       public string WriterName{get;set;}  // Redundant

       public IEnumerable<string> Genres{get;set;} // Redundant

       public decimal Price {get;set;}

       public string LanguageName { get; set; }

       public string PublisherName { get; set; }

       public int TranslatorId { get; set; }
    }
}