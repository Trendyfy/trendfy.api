using Algolia.Search.Clients;
using Auth.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Infrastructure.HttpClients;
using Infrastructure.HttpClients.Interfaces;
using Infrastructure.Repositories.Algolia;
using Infrastructure.Repositories.Firestore;
using Infrastructure.Repositories.Firestore.Base;
using Infrastructure.Repositories.Firestore.Base.Infrastructure.Repositories.Firestore.Base;
using Microsoft.Extensions.DependencyInjection;
using MusicAssistentAI.AutoMapper;
using MusicAssistentAI.Interfaces;
using MusicAssistentAI.Services;
using PaymentProvider.Interfaces;
using PaymentProvider.Providers.IoPay;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables();

builder.Services.AddScoped<IComposeMusicService, ComposeMusicService>();
builder.Services.AddScoped<IMusicAlgoliaRepository, MusicAlgoliaRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpClient("IOPayClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["IOPay:ApiUrl"]);
});

builder.Services.AddScoped<IPaymentProvider, IOPayService>();

builder.Services.AddHttpClient<ISunoClient, SunoClient>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(builder.Configuration["Ai:ApiUrl"]);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["Ai:ApiToken"]}");

});

var firebaseCredentialJson = builder.Configuration["Firebase:AdminSDK"];
if (string.IsNullOrEmpty(firebaseCredentialJson))
    throw new InvalidOperationException("Firebase Admin SDK credentials not found in secrets.");

var firebaseCredentialBytes = Encoding.UTF8.GetBytes(firebaseCredentialJson);
var stream = new MemoryStream(firebaseCredentialBytes);
var gcpCredentials = GoogleCredential.FromStream(stream);
FirebaseApp.Create(new AppOptions()
{
    Credential = gcpCredentials
});

var firestoreDbBuilder = new FirestoreDbBuilder
{
    ProjectId = builder.Configuration["Firebase:ProjectId"],
    Credential = gcpCredentials
};

builder.Services.AddSingleton(firestoreDbBuilder.Build());

builder.Services.AddScoped(typeof(IFirestoreRepositoryBase<>), typeof(FirestoreRepositoryBase<>));

builder.Services.AddSingleton<ISearchClient>(sp =>
{
    var applicationId = builder.Configuration["Algolia:ApplicationId"];
    var apiKey = builder.Configuration["Algolia:ApiKey"];
    return new SearchClient(applicationId, apiKey);
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


