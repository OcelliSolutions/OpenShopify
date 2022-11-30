using System.Text.Json.Serialization;
using Ocelli.OpenShopify;
using SampleApp.Extensions;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<MvcJsonOptions>(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/signup", (string hmac, string shop, long timestamp, HttpContext httpContext) =>
    {
        if (hmac == null) throw new ArgumentNullException(nameof(hmac));
        if (timestamp <= 0) throw new ArgumentOutOfRangeException(nameof(timestamp));

        //TODO: the following scopes require review from Shopify to enable. Do not include them for now.
        var extendedPermissions = new List<AuthorizationScope>
        {
            AuthorizationScope.ReadAllOrders, 
            AuthorizationScope.WriteUsers, 
            AuthorizationScope.ReadUsers, 
            //AuthorizationScope.WriteLocations,

            AuthorizationScope.ReadCustomerPaymentMethods,
            AuthorizationScope.WriteOwnSubscriptionContracts,
            AuthorizationScope.ReadOwnSubscriptionContracts
        };
        var scopes = Enum.GetValues(typeof(AuthorizationScope))
            .Cast<AuthorizationScope>()
            .Where(d => !extendedPermissions.Contains(d))
            .Select(EnumExtensions.GetEnumMemberValue)
            .ToList();
        
        var redirectUrl = new UriBuilder()
            { Scheme = "http", Host = "localhost", Port = httpContext.Connection.LocalPort, Path = "redirect" };
        var apiKey = app.Configuration["Shopify:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new KeyNotFoundException("Please add an ApiKey to appsettings.Developer.json");
        var authUrl = AuthorizationService.BuildAuthorizationUrl(scopes, shop, apiKey, redirectUrl.ToString());
        return Results.Redirect(authUrl.ToString());
    })
    .WithName("SignUp");


app.MapGet("/redirect",
        async (string code, string hmac, string host, string shop, long timestamp) =>
        {
            var apiKey = app.Configuration["Shopify:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new KeyNotFoundException("Please add an ApiKey to appsettings.Developer.json");

            var apiSecret = app.Configuration["Shopify:ApiSecret"];
            if (string.IsNullOrWhiteSpace(apiSecret))
                throw new KeyNotFoundException("Please add an apiSecret to appsettings.Developer.json");

            var accessToken = await AuthorizationService.Authorize(code, shop, apiKey, apiSecret);
            return Results.Ok(new AccessToken(accessToken, shop));
        })
    .WithName("ReceiveAccessCode");

app.Run();
internal record AccessToken(string access_token, string my_shopify_url);