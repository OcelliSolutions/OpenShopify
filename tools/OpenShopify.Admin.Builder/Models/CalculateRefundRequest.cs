using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record CalculateRefundRequest
{
    [JsonPropertyName("refund")]
    public CalculateRefundRequestDetail Refund { get; set; } = null!;
}