
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify payments transaction.
    /// </summary>
    public partial record ShopifyPaymentsTransaction : ShopifyObject
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("payout_id")]
        public long? PayoutId { get; set; }

        [JsonPropertyName("payout_status")]
        public string? PayoutStatus { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }

        [JsonPropertyName("net")]
        public decimal? Net { get; set; }

        [JsonPropertyName("source_id")]
        public long? SourceId { get; set; }

        [JsonPropertyName("source_type")]
        public string? SourceType { get; set; }

        [JsonPropertyName("source_order_transaction_id")]
        public long? SourceOrderTransactionId { get; set; }

        [JsonPropertyName("source_order_id")]
        public long? SourceOrderId { get; set; }

        [JsonPropertyName("processed_at")]
        public DateTimeOffset? ProcessedAt { get; set; }


    }
}
