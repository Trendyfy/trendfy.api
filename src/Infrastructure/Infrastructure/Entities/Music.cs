using Newtonsoft.Json;

namespace Infrastructure.Entities
{
    public class Music
    {
        [JsonProperty("objectID")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Lyric { get; set; }
        public string AudioUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Tags { get; set; }
    }
}
