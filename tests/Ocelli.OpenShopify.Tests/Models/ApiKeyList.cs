using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ocelli.OpenShopify.Tests.Models;
internal class ApiKeyList
{
    [JsonPropertyName("days_to_test")]
    public int DaysToTest { get; set; } = 1;
    [JsonPropertyName("configs")]
    public List<ShopifyConfig>? ShopifyConfigs { get; set; }
}

internal class ShopifyConfig
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("my_shopify_url")] public string MyShopifyUrl { get; set; } = null!;
}
