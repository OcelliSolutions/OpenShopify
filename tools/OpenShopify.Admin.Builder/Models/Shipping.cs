using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record Shipping
{
    /// <summary>
    /// Whether to refund all remaining shipping.
    /// </summary>
    [JsonPropertyName("full_refund")]
    public bool? FullRefund { get; set; }

    /// <summary>
    /// Set a specific amount to refund for shipping. Takes precedence over full_refund.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// The maximum amount that can be refunded
    /// </summary>
    [JsonPropertyName("maximum_refundable")]
    public decimal? MaximumRefundable { get; set; }
        
    [JsonPropertyName("tax")]
    public decimal? Tax { get; set; }
}