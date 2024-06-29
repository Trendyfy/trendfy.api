using Music.IO.Data.Entities.Exceptions;
using Music.IO.Data.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Music.IO.Data.Entities.Searching
{
    public static class SearchDataValidate
    {
        public static void Validate(SearchData data)
        {
            var field = data.Query.FirstOrDefault(x =>
                            (x.Operator == SearchDataQueryOperator.InList && x.Values.Count > SearchDataHelpers.MaxElementInQueryValue[x.Operator]) ||
                            (x.Operator == SearchDataQueryOperator.NotInList && x.Values.Count > SearchDataHelpers.MaxElementInQueryValue[x.Operator]) ||
                            (x.Values.Count != SearchDataHelpers.MaxElementInQueryValue[x.Operator]));
            if (field != null)
                throw new IODataSearchException($"The '{field.Fieldname}' field supports a maximum of {SearchDataHelpers.MaxElementInQueryValue[field.Operator]} element(s) as a filter value.");
        }
    }
}
