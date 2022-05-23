
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify payments payout.
    /// </summary>
    public partial record ShopifyPaymentsPayout : ShopifyObject
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("summary")]
        public ShopifyPaymentsPayoutSummary? Summary { get; set; }
    }
}
