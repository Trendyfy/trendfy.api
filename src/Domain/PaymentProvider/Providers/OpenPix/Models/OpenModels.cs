using Newtonsoft.Json;

namespace PaymentProvider.Providers.Cora.Models
{
    public class OpenPixRequest
    {
        [JsonProperty("qrCode")]
        public string qrCode { get; set; }
        [JsonProperty("correlationID")]
        public string correlationID { get; set; }

        public string sourceAccountId { get; set; }
    }
}
