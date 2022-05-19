using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class Currency
{
    [JsonPropertyName("currency")] public string CurrencyCode { get; set; } = null!;
    [JsonPropertyName("rate_updated_at")] public DateTimeOffset RateUpdatedAt { get; set; }
    [JsonPropertyName("enabled")] public bool Enabled { get; set; }
}
