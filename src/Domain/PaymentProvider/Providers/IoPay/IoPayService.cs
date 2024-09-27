using Auth.Services;
using Infrastructure.Entities;
using Infrastructure.Repositories.Firestore;
using Microsoft.Extensions.Configuration;
using PaymentProvider.Interfaces;
using PaymentProvider.Models;
using PaymentProvider.Providers.OpenPix.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PaymentProvider.Providers.IoPay
{
    public class IOPayService : IPaymentProvider
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;
        private readonly HttpClient _httpClient;
        private readonly string _email;
        private readonly string _secret;
        private readonly string _ioSellerId;
        private string _token;

        public IOPayService(ITransactionRepository transactionRepository, IUserService userService, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
            _httpClient = httpClientFactory.CreateClient("IOPayClient");
            _email = configuration["IOPay:email"];
            _secret = configuration["IOPay:secret"];
            _ioSellerId = configuration["IOPay:sellerId"];
        }

        private async Task<string> GetTokenAsync()
        {
            var content = JsonContent.Create(new
            {
                email = _email,
                secret = _secret,
                io_seller_id = _ioSellerId
            });

            var response = await _httpClient.PostAsync($"auth/login", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);
            _token = tokenResponse.access_token;

            return _token;
        }

        public async Task<bool> ProcessPayment(PaymentRequest payment, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_token))
            {
                await GetTokenAsync();
            }

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            payment.IoSellerId = _ioSellerId;

            var body = JsonSerializer.Serialize(payment);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"v1/transaction/new/{payment.ReferenceId}", content);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transaction = JsonSerializer.Deserialize<TransactionResponse>(jsonResponse);

            var transactionCreated = _transactionRepository
                .Create(new Infrastructure.Entities.Transaction() { UserId = payment.ReferenceId }, cancellationToken);

            return transaction.TransactionId != null;
        }

        public async Task<bool> TransactionWebhook(PaymentWebHook payment, CancellationToken cancellationToken)
        {

            if (payment.EventType.Equals("transaction.succeeded"))
            {
                var transaction = await _transactionRepository.GetById("1", cancellationToken);

                if (transaction == null)
                    throw new Exception("transaction notfound");

                if (transaction.Status == TransactionStatus.Pending)
                {
                    var userUpdate = await _userService.AddCredits(transaction.Id, transaction.UserId, transaction.Amount);

                    if (userUpdate)
                    {
                        await _transactionRepository
                            .Update(transaction.Id, new Transaction() { Status = TransactionStatus.Processed }, cancellationToken);

                        return true;
                    }
                };
            }

            return false;

        }

        public Task<bool> TransactionWebhook(TransactionReceivedEvent payment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class TokenResponse
    {
        public string access_token { get; set; }
    }

    public class TransactionResponse
    {
        // Defina as propriedades de acordo com a resposta real da API
        public string TransactionId { get; set; }
        public string Status { get; set; }
        // Adicione outras propriedades conforme necessário
    }
}
