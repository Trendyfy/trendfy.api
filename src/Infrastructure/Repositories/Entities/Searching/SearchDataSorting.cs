using System.Text.Json.Serialization;

namespace Rabbot.Jedi.Data.Searching
{
    public class SearchDataSorting
    {
        public string Fieldname { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SearchDataOrder Order { get; set; }
    }
}
