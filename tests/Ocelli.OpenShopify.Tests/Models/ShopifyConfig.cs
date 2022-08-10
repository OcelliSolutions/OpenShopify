using System.Text.Json.Serialization;

namespace Ocelli.OpenShopify.Tests.Models;
internal class ShopifyConfig
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("api_key")]
    public string ApiKey { get; set; } = null!;

    [JsonPropertyName("api_secret")]
    public string ApiSecret { get; set; } = null!;

    [JsonPropertyName("my_shopify_url")] 
    public string MyShopifyUrl { get; set; } = null!;

    [JsonPropertyName("webhook")]
    public WebhookTest? Webhook { get; set; }

    [JsonPropertyName("callback_url")]
    public string CallbackUrl { get; set; } = null!;
}