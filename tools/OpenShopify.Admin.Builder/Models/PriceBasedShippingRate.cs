using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class PriceBasedShippingRate : ShopifyObject
    {
        /// <summary>
        /// The name of the price based shipping rate, specified by the user.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Minimum order price
        /// </summary>
        [JsonPropertyName("min_order_subtotal")]
        public decimal? MinOrderSubtotal { get; set; }

        /// <summary>
        /// Rate amount
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Maximum order price
        /// </summary>
        [JsonPropertyName("max_order_subtotal")]
        public decimal? MaxOrderSubtotal { get; set; }

        /// <summary>
        /// Shipping zone id
        /// </summary>
        [JsonPropertyName("shipping_zone_id")]
        public long? ShippingZoneId { get; set; }
    }
}