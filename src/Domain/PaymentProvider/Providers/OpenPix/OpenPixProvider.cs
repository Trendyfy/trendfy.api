using Auth.Services;
using PaymentProvider.Interfaces;
using PaymentProvider.Models;
using PaymentProvider.Providers.Cora.Models;
using PaymentProvider.Providers.OpenPix.Models;
using System.Text;
using System.Text.Json;

namespace PaymentProvider.Providers.Cora
{

    public class OpenPixProvider : IPaymentProvider
    {
        private readonly HttpClient _client;
        private readonly IUserService _userService;

        public OpenPixProvider(IUserService userService, IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("OpenPixClient");
            _userService = userService;
        }

        public async Task<bool> OpenPixWebhook(TransactionReceivedEvent payment, CancellationToken cancellationToken)
        {
            if (payment.Event.Equals("OPENPIX:TRANSACTION_RECEIVED"))
            {
                var planResult = await _userService.SetUserPlan(payment.Charge.CorrelationID);
                if (!planResult)
                    throw new Exception("Error while process the plan");
            }
            return false;
        }

        public async Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken)
        {
            var request = new OpenPixRequest();
            request.correlationID = "238432564234723492374289";
            request.qrCode = "f3daf614ad074fb0b783a1b70";
            request.sourceAccountId = "e12c10f0-0aff-4754-a942-ae654b8c400e";

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("payment", content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Handle error (e.g., log the error, throw an exception, etc.)
                return false;
            }
        }
    }

}
