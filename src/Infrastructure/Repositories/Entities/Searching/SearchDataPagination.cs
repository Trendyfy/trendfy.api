using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbot.Jedi.Data.Searching
{
    public class SearchDataPagination
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 200;
        public int From { get { return (PageNumber - 1) * PageSize; } }
    }
}
