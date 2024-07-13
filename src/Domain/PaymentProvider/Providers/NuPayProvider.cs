using PaymentProvider.Interfaces;
using PaymentProvider.Models;

namespace PaymentProvider.Providers
{
    public class NuPayProvider : IPaymentProvider
    {
        public async Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken)
        {
            // Implementação da lógica de pagamento do Stripe
            return await Task.FromResult(true);
        }
    }
}
