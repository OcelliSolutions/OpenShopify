using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment.
    /// </summary>
    public partial record FulfillmentBase
    {
        /// <inheritdoc cref="FulfillmentOrig.LineItems"/>
        [JsonPropertyName("line_items")]
        public new IEnumerable<LineItem>? LineItems { get; set; }

        /// <inheritdoc cref="FulfillmentOrig.Receipt"/>
        [JsonPropertyName("origin_address")]
        public new Address? OriginAddress { get; set; }

        /// <inheritdoc cref="FulfillmentOrig.Receipt"/>
        [JsonPropertyName("receipt")]
        public new Receipt? Receipt { get; set; }

        /// <inheritdoc cref="FulfillmentOrig.ShipmentStatus"/>
        [JsonPropertyName("shipment_status")]
        public new FulfillmentShipmentStatus? ShipmentStatus { get; set; }

        /// <inheritdoc cref="FulfillmentOrig.Status"/>
        [JsonPropertyName("status")]
        public new FulfillmentStatus? Status { get; set; }

        [JsonPropertyName("tracking_number")]
        public string? TrackingNumber { get; set; } = default!;

        /// <summary>
        /// The URLs of tracking pages for the fulfillment.
        /// </summary>

        [JsonPropertyName("tracking_url")]
        public string? TrackingUrl { get; set; } = default!;
    }
}
