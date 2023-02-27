namespace UzTexGroupV2.Model
{
    public class Pagenation
    {
        public Pagenation(int totalPages, int pageSize, int currentPage)
        {
            TotalPages = totalPages;
            PageCount = (int)Math.Ceiling(1.0 * totalPages / pageSize);
            CurrentPage = currentPage;
        }

        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage  { get; set;}
        public bool HasNextPage 
        { 
            get
            {
               return CurrentPage < PageCount;
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return CurrentPage > 1 && CurrentPage <= TotalPages;
            }
        }


    }
}
