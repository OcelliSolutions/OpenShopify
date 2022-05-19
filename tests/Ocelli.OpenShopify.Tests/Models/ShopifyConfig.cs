using System.Text.Json.Serialization;

namespace Ocelli.OpenShopify.Tests.Models;
internal class ShopifyConfig
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("my_shopify_url")] public string MyShopifyUrl { get; set; } = null!;
}
