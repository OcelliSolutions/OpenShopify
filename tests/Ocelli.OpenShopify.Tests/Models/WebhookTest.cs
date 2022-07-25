using System.Text.Json.Serialization;

namespace Ocelli.OpenShopify.Tests.Models;

public class WebhookTest
{
    [JsonPropertyName("hmac")]
    public string Hmac { get; set; } = null!;
    [JsonPropertyName("data")]
    public dynamic Data { get; set; } = null!;
}