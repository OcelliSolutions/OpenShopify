using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record PaymentRequestDetail
{
    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }
    [JsonPropertyName("accept_language")]
    public string? AcceptLanguage { get; set; }
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }
}