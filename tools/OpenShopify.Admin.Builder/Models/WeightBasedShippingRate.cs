using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record WeightBasedShippingRate : ShopifyObject
    {
        /// <summary>
        /// Minimum order weight
        /// </summary>
        [JsonPropertyName("weight_low")]
        public decimal? WeightLow { get; set; }

        /// <summary>
        /// Maximum order weight
        /// </summary>
        [JsonPropertyName("weight_high")]
        public decimal? WeightHigh { get; set; }

        /// <summary>
        /// Name of weight based rate
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Rate amount
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Shipping zone id
        /// </summary>
        [JsonPropertyName("shipping_zone_id")]
        public long? ShippingZoneId { get; set; }
    }
}