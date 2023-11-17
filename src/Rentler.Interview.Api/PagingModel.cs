namespace Rentler.Interview.Api
{
    public class PagingModel
    {
        const int maxPageSize = 10;

        public int PageNumber { get; set; } = 1;

        public string SearchTerm { get; set; } = string.Empty;

        private int _pageSize { get; set; } = 5;

        public int PageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
