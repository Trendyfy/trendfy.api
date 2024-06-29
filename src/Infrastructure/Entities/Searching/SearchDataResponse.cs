using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.IO.Data.Searching
{
    public class SearchDataResponse<T>
    {
        public SearchDataResponse(SearchDataResponseMetadata metadata, IEnumerable<T> data)
        { 
            Metadata = metadata;
            Data = data;
        }
        public SearchDataResponseMetadata Metadata { get; }
        public IEnumerable<T> Data { get; }
    }

    public class SearchDataResponseMetadata
    {
        /// <summary>
        /// Number of page return.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Max of element on each page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Total of page 
        /// </summary>
        public long PageCount { get; set; }
        /// <summary>
        /// Total of itens return on request
        /// </summary>
        public int PageItemsCount { get; set; }
        /// <summary>
        /// Total of itens in database
        /// </summary>
        public long ItemsCount { get; set;}
    }

}
