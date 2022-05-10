using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class MerchantRequestOptions
    {
        [JsonPropertyName("shipping_method")]
        public string? ShippingMethod { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset? Date { get; set; }
    }
}