using Algolia.Search.Clients;
using Auth.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.HttpClients;
using Infrastructure.HttpClients.Interfaces;
using Infrastructure.Repositories;
using MusicAssistentAI.AutoMapper;
using MusicAssistentAI.Interfaces;
using MusicAssistentAI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables();

builder.Services.AddScoped<IComposeMusicService, ComposeMusicService>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
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
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromStream(stream)
});

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
