using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbot.Jedi.Data.Searching
{
    public class SearchData
    {
        public List<SearchDataSorting> Sorting { get; set; } = new List<SearchDataSorting>();
        public List<SearchDataQueryField> Query { get; set; } = new List<SearchDataQueryField>();
        public SearchDataPagination Pagination { get; set; } = new SearchDataPagination();
    }
}
