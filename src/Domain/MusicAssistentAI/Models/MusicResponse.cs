namespace MusicManager.Models
{
    public class MusicResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Lyric { get; set; }
        public string AudioUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Tags { get; set; }
    }
}
