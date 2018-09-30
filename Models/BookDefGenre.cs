namespace bookshop.Models
{
    public class BookDefGenre
    {
        public int BookDefId{get;set;}

        public BookDef BookDef {get;set;}

        public int GenreId{get;set;}

        public Genre Genre{get;set;}
    }
}