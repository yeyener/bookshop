namespace bookshop.QueryObjects.Resources
{
    public class BookInstQueryObjectResource
    {
        public string WriterNameLike{get;set;}

        public int WriterId {get;set;}

        public string GenreNameLike{get;set;}

        public string SortBy { get; set; }

        public bool IsSortAsc { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}