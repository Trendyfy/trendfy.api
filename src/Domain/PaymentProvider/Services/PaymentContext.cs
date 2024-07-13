using PaymentProvider.Interfaces;
using PaymentProvider.Models;

namespace PaymentProvider.Services
{
    public class PaymentContext
    {
        private IPaymentProvider _paymentProvider;

        public PaymentContext(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        public void SetPaymentProvider(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        public async Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken)
        {
            return await _paymentProvider.ProcessPayment(payment, cancellationToken);
        }
    }
}
