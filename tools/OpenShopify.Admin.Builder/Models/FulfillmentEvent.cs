using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment event.
    /// </summary>
    public class FulfillmentEvent : ShopifyObject
    {
        /// <summary>
        /// The date and time when the fulfillment event was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The unique numeric identifier for the order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        /// <summary>
        /// The unique numeric identifier for the shop.
        /// </summary>
        [JsonPropertyName("shop_id")]
        public long? ShopId { get; set; }

        /// <summary>
        /// The unique numeric identifier for the fulfillment.
        /// </summary>
        [JsonPropertyName("fulfillment_id")]
        public long? FulfillmentId { get; set; }

        /// <summary>
        /// The status of the fulfillment event. Valid values are 'confirmed', 'in_transit', 
        /// 'out_for_delivery', 'delivered' and 'failure'
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The date and time when the fulfillment event occurred
        /// </summary>
        [JsonPropertyName("happened_at")]
        public DateTimeOffset? HappenedAt { get; set; }

        /// <summary>
        /// An arbitrary message describing the status.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The city in which the fulfillment event occurred.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// The province in which the fulfillment event occurred.
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        /// The zip code in the location in which the fulfillment event occurred.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        /// <summary>
        /// The country in which the fulfillment event occurred.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// The fulfillment event's street address.
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// Geographic coordinate specifying the north/south location of a fulfillment event.
        /// </summary>
        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Geographic coordinate specifying the east/west location of a fulfillment event.
        /// </summary>
        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }

        /// <summary>
        /// The estimated date of delivery.
        /// </summary>
        [JsonPropertyName("estimated_delivery_at")]
        public DateTimeOffset? EstimatedDeliveryAt { get; set; }

        /// <summary>
        /// The date and time when the fulfillment event was last modified.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
