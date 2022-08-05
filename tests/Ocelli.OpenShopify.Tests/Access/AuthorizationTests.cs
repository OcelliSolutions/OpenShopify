using System;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Ocelli.OpenShopify.Tests.Access;
public class AuthorizationScopeFixture : SharedFixture, IAsyncLifetime
{
    public AuthorizationScopeFixture() =>
        Service = new AccessService(MyShopifyUrl, AccessToken);

    public IAccessService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}



[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("AuthorizationTests")]
public class AuthorizationTests : IClassFixture<AuthorizationScopeFixture>
{
    public AuthorizationTests(AuthorizationScopeFixture fixture)
    {
        Fixture = fixture;
    }

    private AuthorizationScopeFixture Fixture { get; }

    [Fact]
    public void Validates_Proxy_Requests()
    {
        //Configure querystring
        var qs = new Dictionary<string, StringValues>()
        {
            {"shop", "stages-test-shop-2.myshopify.com"},
            {"path_prefix", "/apps/stages-order-tracker"},
            {"timestamp", "1459781841"},
            {"signature", "239813a42e1164a9f52e85b2119b752774fafb26d0f730359c86572e1791854a"},
        };

        var isValid = AuthorizationService.IsAuthenticProxyRequest(qs, Fixture.SecretKey);

        Assert.True(isValid);
    }


    [Fact]
    public void Validates_Proxy_Requests_With_Dictionary_QueryString()
    {
        //Configure querystring
        var qs = new Dictionary<string, StringValues>()
            {
                {"shop", "stages-test-shop-2.myshopify.com"},
                {"path_prefix", "/apps/stages-order-tracker"},
                {"timestamp", "1459781841"},
                {"signature", "239813a42e1164a9f52e85b2119b752774fafb26d0f730359c86572e1791854a"},
            };

        var isValid = AuthorizationService.IsAuthenticProxyRequest(qs, Fixture.SecretKey);

        Assert.True(isValid);
    }

    [Fact]
    public void Validates_Proxy_Requests_With_Raw_QueryString()
    {
        //Configure querystring
        const string qs = "shop=stages-test-shop-2.myshopify.com&path_prefix=/apps/stages-order-tracker&timestamp=1459781841&signature=239813a42e1164a9f52e85b2119b752774fafb26d0f730359c86572e1791854a";

        var isValid = AuthorizationService.IsAuthenticProxyRequest(qs, Fixture.SecretKey);

        Assert.True(isValid);
    }

    [Fact]
    public void Validates_Web_Requests()
    {
        var qs = new Dictionary<string, StringValues>()
            {
                {"hmac", "134298b94779fc1be04851ed8f972c827d9a3b4fdf6725fe97369ef422cc5746"},
                {"shop", "stages-test-shop-2.myshopify.com"},
                {"signature", "f477a85f3ed6027735589159f9da74da"},
                {"timestamp", "1459779785"},
            };

        var isValid = AuthorizationService.IsAuthenticRequest(qs, Fixture.SecretKey);

        Assert.True(isValid);
    }

    [Fact(Skip = "TODO: Generate a real query string with the shop and secret key used by the build server, which contains an ids[] parameter")]
    public void Validates_Web_Requests_WithArrayParameter()
    {
        const string query = "hmac=...";
        var qs = QueryHelpers.ParseQuery(query);
        var isValid = AuthorizationService.IsAuthenticRequest(qs, Fixture.SecretKey);
        Assert.True(isValid);
    }

    [Fact(Skip = "TODO: Generate a real query string with the shop and secret key used by the build server, which contains an ids[] parameter with a single value")]
    public void Validates_Web_Requests_WithArrayParameter_SingleValue()
    {
        const string query = "hmac=...";
        var qs = QueryHelpers.ParseQuery(query);
        var isValid = AuthorizationService.IsAuthenticRequest(qs, Fixture.SecretKey);
        Assert.True(isValid);
    }

    [Fact]
    public void Validates_Web_Requests_With_Dictionary_Querystring()
    {
        // Note that this method differes from Validates_Web_Requests() in that the aforementioned's dictionary is Dictionary<string, stringvalues> and this is Dictionary<string, string>.
        var qs = new Dictionary<string, string>()
            {
                {"hmac", "134298b94779fc1be04851ed8f972c827d9a3b4fdf6725fe97369ef422cc5746"},
                {"shop", "stages-test-shop-2.myshopify.com"},
                {"signature", "f477a85f3ed6027735589159f9da74da"},
                {"timestamp", "1459779785"},
            };

        var isValid = AuthorizationService.IsAuthenticRequest(qs, Fixture.SecretKey);

        Assert.True(isValid);
    }

    [Fact]
    public void Validates_Web_Requests_With_Raw_Querystring()
    {
        const string qs = "hmac=134298b94779fc1be04851ed8f972c827d9a3b4fdf6725fe97369ef422cc5746&shop=stages-test-shop-2.myshopify.com&signature=f477a85f3ed6027735589159f9da74da&timestamp=1459779785";

        Assert.True(AuthorizationService.IsAuthenticRequest(qs, Fixture.SecretKey));
    }

    [Fact]
    public async Task Validates_Shop_Urls()
    {
        var validUrl = Fixture.MyShopifyUrl;
        const string invalidUrl = "https://google.com";

        Assert.True(await AuthorizationService.IsValidShopDomainAsync(validUrl));
        Assert.False(await AuthorizationService.IsValidShopDomainAsync(invalidUrl));
    }

    [Fact]
    public async Task Validates_Shop_Malfunctioned_Urls()
    {
        const string invalidUrl = "foo";

        Assert.False(await AuthorizationService.IsValidShopDomainAsync(invalidUrl));
    }

    [SkippableFact]
    public void Validates_Webhook_ByStream()
    {
        Skip.If(Fixture.WebhookTest?.Hmac == null, "Define a test webhook response in `api_key.json`");
        var qs = new List<KeyValuePair<string, StringValues>>()
        {
            new ("X-Shopify-Hmac-SHA256" , Fixture.WebhookTest.Hmac )
        };
        var data = JsonSerializer.Serialize(Fixture.WebhookTest.Data);
        var isValid = AuthorizationService.IsAuthenticWebhook(qs, data, Fixture.SecretKey);
        Assert.True(isValid);
    }

    [SkippableFact]
    public void Validates_Webhook_ByString()
    {
        Skip.If(Fixture.WebhookTest?.Hmac == null, "Define a test webhook response in `api_key.json`");
        var qs = new List<KeyValuePair<string, StringValues>>()
        {
            new ("X-Shopify-Hmac-SHA256" , Fixture.WebhookTest.Hmac )
        };
        var isValid = AuthorizationService.IsAuthenticWebhook(qs, Fixture.WebhookTest.Data, Fixture.SecretKey);
        Assert.True(isValid);
    }

    [SkippableFact]
    public void Validates_Webhook_ByStringWithHeaders()
    {
        Skip.If(Fixture.WebhookTest?.Hmac == null, "Define a test webhook response in `api_key.json`");
        var headers = new HttpRequestMessage().Headers;
        headers.Add("X-Shopify-Hmac-SHA256", Fixture.WebhookTest.Hmac);
        var data = JsonSerializer.Serialize(Fixture.WebhookTest.Data);
        var isValid = AuthorizationService.IsAuthenticWebhook(headers, data, Fixture.SecretKey);
        Assert.True(isValid);
    }

    [Fact]
    public void Builds_Authorization_Urls_With_Enums()
    {
        var scopes = new List<AuthorizationScope>()
            {
                AuthorizationScope.ReadCustomers,
                AuthorizationScope.WriteCustomers
            };
        var redirectUrl = "http://example.com";
        var result = AuthorizationService.BuildAuthorizationUrl(scopes, Fixture.MyShopifyUrl, Fixture.ApiKey, redirectUrl).ToString();

        Assert.Contains($"/admin/oauth/authorize?", result);
        Assert.Contains($"client_id={Fixture.ApiKey}", result);
        Assert.Contains($"scope=read_customers,write_customers", result);
        Assert.Contains($"redirect_uri={redirectUrl}", result);
    }

    [Fact]
    public void Builds_Authorization_Urls_With_Strings()
    {
        string[] scopes = { "read_customers", "write_customers" };
        const string redirectUrl = "http://example.com";
        var result = AuthorizationService.BuildAuthorizationUrl(scopes, Fixture.MyShopifyUrl, Fixture.ApiKey, redirectUrl).ToString();

        Assert.Contains($"/admin/oauth/authorize?", result);
        Assert.Contains($"client_id={Fixture.ApiKey}", result);
        Assert.Contains($"scope=read_customers,write_customers", result);
        Assert.Contains($"redirect_uri={redirectUrl}", result);
    }

    [Fact]
    public void Builds_Authorization_Urls_With_Grants_And_State()
    {
        var scopes = new [] { "read_customers", "write_customers" };
        const string redirectUrl = "http://example.com";
        var grants = new[] { "per-user" };
        var state = Guid.NewGuid().ToString();
        var result = AuthorizationService.BuildAuthorizationUrl(scopes, Fixture.MyShopifyUrl, Fixture.ApiKey, redirectUrl, state, grants).ToString();

        Assert.Contains($"/admin/oauth/authorize?", result);
        Assert.Contains($"client_id={Fixture.ApiKey}", result);
        Assert.Contains($"scope=read_customers,write_customers", result);
        Assert.Contains($"redirect_uri={redirectUrl}", result);
        Assert.Contains($"state={state}", result);
        Assert.Contains($"grant_options[]=per-user", result);
    }
}
