using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public record FulfillmentHoldRequestDetail
{
    /// <summary>
    /// Whether the merchant should receive a notification about the fulfillment hold. If set to true, then the merchant will be notified on the Shopify mobile app (if they use it to manage their store). The default value is false
    /// </summary>
    [JsonPropertyName("notify_merchant")]
    public bool? NotifyMerchant { get; set; }

    /// <summary>
    /// A mandatory reason for the fulfillment hold
    /// </summary>
    [JsonPropertyName("reason")]
    public FulfillmentHoldReason? Reason { get; set; }

    /// <summary>
    /// Optional additional information about the fulfillment hold reason.
    /// </summary>
    [JsonPropertyName("reason_notes")]
    public string? ReasonNotes { get; set; }
}