using PaymentProvider.Models;

namespace PaymentProvider.Interfaces
{
    public interface IPaymentProvider
    {
        Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken);
    }
}
