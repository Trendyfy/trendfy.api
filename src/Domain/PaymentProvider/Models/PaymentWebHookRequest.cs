namespace PaymentProvider.Models
{
    using System.Text.Json.Serialization;

    public class PaymentWebHook
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string EventType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }
    }    
}
