using PaymentProvider.Interfaces;
using PaymentProvider.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PaymentProvider.Providers.Cora
{

    public class CoraProvider : IPaymentProvider
    {
        private readonly HttpClient _client;
        private readonly IAuthenticationCoraService _authenticationService;

        public CoraProvider(IHttpClientFactory httpClientFactory, IAuthenticationCoraService authenticationService)
        {
            _client = httpClientFactory.CreateClient("CoraClient"); 
            _authenticationService = authenticationService;
        }

        public async Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.GetTokenAsync(cancellationToken);   
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var idempotencyKey = Guid.NewGuid().ToString();
            _client.DefaultRequestHeaders.Add("Idempotency-Key", idempotencyKey);

            var json = JsonSerializer.Serialize(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("invoices/", content, cancellationToken);

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
