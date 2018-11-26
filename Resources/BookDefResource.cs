using System.Collections.Generic;
using System.Collections.ObjectModel;
using bookshop.Models;

namespace bookshop.Resources
{
    public class BookDefResource
    {
        public int Id{get;set;}

        public string Name{get;set;}

        public int YearWritten{get;set;}

        
        public int WriterId{get;set;}

        public string WriterName{get;set;}

        public Collection<Genre> Genres{get;set;}

        public BookDefResource()
        {
            Genres = new Collection<Genre>();
        }
    }
}