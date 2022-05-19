using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ocelli.OpenShopify;

public abstract class ShopifyService
{
    protected const string Version = "2022-04";
    internal static ConcurrentDictionary<string, HttpClient> ShopifyHttpClients = new();
    protected JsonSerializerOptions Options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};

    /// <summary>
    /// Creates a new instance of <see cref="ShopifyService" />.
    /// </summary>
    /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
    /// <param name="shopAccessToken">An API access token for the shop.</param>
    /// <param name="isPlusStore"></param>
    protected ShopifyService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false)
    {
        var httpClient = new HttpClient(new RateLimitHttpMessageHandler
        {
            InnerHandler = new HttpClientHandler(), 
            CallsPerMinute = isPlusStore ? 80 : 40
        });
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Shopify-Access-Token", shopAccessToken);

        ShopifyHttpClients.TryAdd(myShopifyUrl, httpClient);
    }

    protected Uri PrepareRequest(string myShopifyUrl)
    {
        var ub = new UriBuilder()
        {
            Scheme = "https://", 
            Host = myShopifyUrl, 
            Port = 443, 
            Path = $"admin/api/{Version}/"
        };
        return ub.Uri;
    }
}