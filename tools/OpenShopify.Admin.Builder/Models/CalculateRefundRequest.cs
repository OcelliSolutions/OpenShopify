using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record CalculateRefundRequest
{
    [JsonPropertyName("refund")]
    public CalculateRefundRequestDetail Refund { get; set; } = null!;
}

public record CalculateRefundRequestDetail
{
    /// <inheritdoc cref="RefundBase.Currency"/>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <inheritdoc cref="RefundOrig.RefundLineItems"/>
    [JsonPropertyName("refund_line_items")]
    public IEnumerable<RefundLineItem>? RefundLineItems { get; set; }

    /// <inheritdoc cref="RefundBase.Shipping"/>
    [JsonPropertyName("shipping")]
    public Shipping? Shipping { get; set; }
}
