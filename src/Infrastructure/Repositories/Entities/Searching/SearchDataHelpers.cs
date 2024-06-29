using Rabbot.Jedi.Data.Searching;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbot.Jedi.Data.Entities.Searching
{
    public static class SearchDataHelpers
    {
        public static IDictionary<SearchDataQueryOperator, int> MaxElementInQueryValue = new Dictionary<SearchDataQueryOperator, int> {
            {  SearchDataQueryOperator.Equal, 1 },
            {  SearchDataQueryOperator.GreaterThan, 1 },
            {  SearchDataQueryOperator.GreaterThanOrEqual, 1 },
            {  SearchDataQueryOperator.LessThan, 1 },
            {  SearchDataQueryOperator.LessThanOrEqual, 1 },
            {  SearchDataQueryOperator.NotEqual, 1 },
            {  SearchDataQueryOperator.InList, 100 },
            {  SearchDataQueryOperator.NotInList, 100 },
            {  SearchDataQueryOperator.Between, 2 },
            {  SearchDataQueryOperator.IsNull, 0 },
            {  SearchDataQueryOperator.ArrayIsEmpty, 0 },
            {  SearchDataQueryOperator.Like, 1 },
            {  SearchDataQueryOperator.FullText, 1 }
        };
    }
}
