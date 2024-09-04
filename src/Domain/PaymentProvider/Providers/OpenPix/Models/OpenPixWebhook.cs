namespace PaymentProvider.Providers.OpenPix.Models
{
    public class TransactionReceivedEvent
    {
        public string Event { get; set; }
        public Charge Charge { get; set; }
        public Pix Pix { get; set; }
        public Company Company { get; set; }
        public object Account { get; set; }
        public List<object> Refunds { get; set; }
    }

    public class Charge
    {
        public Customer Customer { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public string Identifier { get; set; }
        public string PaymentLinkID { get; set; }
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public List<object> AdditionalInfo { get; set; }
        public int Fee { get; set; }
        public int Discount { get; set; }
        public int ValueWithDiscount { get; set; }
        public DateTime ExpiresDate { get; set; }
        public string Type { get; set; }
        public string CorrelationID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public Payer Payer { get; set; }
        public string BrCode { get; set; }
        public int ExpiresIn { get; set; }
        public string PixKey { get; set; }
        public string PaymentLinkUrl { get; set; }
        public string QrCodeImage { get; set; }
        public string GlobalID { get; set; }
        public PaymentMethods PaymentMethods { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public OpenPixTaxID TaxID { get; set; }
        public string CorrelationID { get; set; }
    }

    public class Payer
    {
        public string Name { get; set; }
        public OpenPixTaxID TaxID { get; set; }
        public string CorrelationID { get; set; }
    }

    public class OpenPixTaxID
    {
        public string TaxID { get; set; }
        public string Type { get; set; }
    }

    public class PaymentMethods
    {
        public PixMethod Pix { get; set; }
    }

    public class PixMethod
    {
        public string Method { get; set; }
        public string TransactionID { get; set; }
        public string Identifier { get; set; }
        public List<object> AdditionalInfo { get; set; }
        public int Fee { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }
        public string TxId { get; set; }
        public string BrCode { get; set; }
        public string QrCodeImage { get; set; }
    }

    public class Pix
    {
        public Customer Customer { get; set; }
        public Payer Payer { get; set; }
        public Charge Charge { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
        public string EndToEndId { get; set; }
        public string TransactionID { get; set; }
        public string InfoPagador { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GlobalID { get; set; }
    }

    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
    }

}
