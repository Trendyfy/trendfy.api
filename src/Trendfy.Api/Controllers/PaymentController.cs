using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Interfaces;
using PaymentProvider.Models;
using PaymentProvider.Providers.OpenPix.Models;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentProvider _paymentProvider;
        public PaymentController(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process(PaymentRequest payment, CancellationToken cancellationToken)
        {
            if (payment is null)
                return BadRequest();

            var result = await _paymentProvider.ProcessPayment(payment, cancellationToken);
            return CreatedAtAction(nameof(Process), result);
        }

        [HttpPost("webhook/openpix")]
        public async Task<IActionResult> Webhook(TransactionReceivedEvent webhookEvent, CancellationToken cancellationToken)
        {
            if (webhookEvent is null)
                return BadRequest();

            var result = await _paymentProvider.TransactionWebhook(webhookEvent, cancellationToken);
            return CreatedAtAction(nameof(Process), result);
        }
    }
}
