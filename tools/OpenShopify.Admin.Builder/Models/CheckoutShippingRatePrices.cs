

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class CheckoutShippingRatePrices
    {
        [JsonPropertyName("totalTax")]
        public string? TotalTax { get; set; }

        [JsonPropertyName("totalPrice")]
        public string? TotalPrice { get; set; }

        [JsonPropertyName("subtotalPrice")]
        public string? SubtotalPrice { get; set; }
    }
}