namespace PaymentProvider.Models
{
    public class PaymentRequest
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Description { get; set; }
    }

    public enum PaymentMethod
    {
        None,
        Pix,
        Credit,
        Debit
    }
}
