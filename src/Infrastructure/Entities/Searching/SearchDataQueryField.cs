using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Music.IO.Data.Searching
{
    public class SearchDataQueryField
    {
        public string Fieldname { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SearchDataQueryOperator Operator { get; set; }
        public IList<string> Values { get; set; } = new List<string>();
    }
}
