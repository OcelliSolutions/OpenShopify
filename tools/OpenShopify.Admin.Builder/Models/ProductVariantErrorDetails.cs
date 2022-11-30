using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record ProductVariantErrorDetails
{
    [JsonPropertyName("variant")]
    public string? Variant { get; set; }
}