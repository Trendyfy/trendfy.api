using System.Text.Json.Serialization;

namespace PaymentProvider.Models
{
    public class PaymentRequest
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonPropertyName("io_seller_id")]
        public string IoSellerId { get; set; }

        [JsonPropertyName("payment_type")]
        public string PaymentType { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }
    }

    public enum PaymentMethod
    {
        None,
        Pix,
        Credit,
        Debit
    }
}
