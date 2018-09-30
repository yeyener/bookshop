using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("BookDefs")]
    public class BookDef
    {
        public int Id{get;set;}

        public string Name{get;set;}

        public int YearWritten{get;set;}

        public Writer Writer{get;set;}

        public int WriterId{get;set;}
        
        public Collection<BookDefGenre> BookDefGenres{get;set;}

          public BookDef(){
              BookDefGenres = new Collection<BookDefGenre>();
          }
    }
}