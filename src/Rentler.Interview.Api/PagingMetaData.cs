using Rentler.Interview.Api.Entities;

namespace Rentler.Interview.Api
{
    public class PagingMetaData
    {        
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }        
        public int TotalPages { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }                
    }
}
