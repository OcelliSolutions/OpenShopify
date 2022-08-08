using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CheckoutLineItem : LineItem
    {
        /// <summary>
        /// The checkout-specific ID of the line item.
        /// </summary>
        [JsonPropertyName("id"), Required]
        public new string Id { get; set; } = null!;

        /// <summary>
        /// The key for the line item.
        /// </summary>
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        /// <summary>
        /// The unique numeric identifier for the product in the fulfillment. Can be null if the original product associated with the order is deleted at a later date
        /// </summary>
        [JsonPropertyName("origin_location_id")]
        public long? OriginLocationId { get; set; }

        /// <inheritdoc cref="LineItem.Properties"/>
        [JsonPropertyName("properties")]
        public new LineItemProperty? Properties { get; set; }
    }
}
