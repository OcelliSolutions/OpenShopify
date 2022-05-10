
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify payments dispute.
    /// </summary>
    public class ShopifyPaymentsDispute : ShopifyObject
    {
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("network_reason_code")]
        public string? NetworkReasonCode { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("evidence_due_by")]
        public DateTimeOffset? EvidenceDueBy { get; set; }

        [JsonPropertyName("initiated_at")]
        public DateTimeOffset? InitiatedAt { get; set; }

        [JsonPropertyName("evidence_sent_on")]
        public DateTimeOffset? EvidenceSentOn { get; set; }

        [JsonPropertyName("finalized_on")]
        public DateTimeOffset? FinalizedOn { get; set; }


    }
}
