using Newtonsoft.Json;

namespace PaymentProvider.Providers.Cora.Models
{
    public class PaymentCoraRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("notification")]
        public Notification Notification { get; set; }

        [JsonProperty("payment_forms")]
        public List<string> PaymentForms { get; set; }
    }

    public class Notification
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
