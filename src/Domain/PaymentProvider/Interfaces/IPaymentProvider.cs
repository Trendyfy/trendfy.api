using PaymentProvider.Models;
using PaymentProvider.Providers.OpenPix.Models;

namespace PaymentProvider.Interfaces
{
    public interface IPaymentProvider
    {
        Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken);
        Task<bool> TransactionWebhook(TransactionReceivedEvent payment, CancellationToken cancellationToken);
    }
}
