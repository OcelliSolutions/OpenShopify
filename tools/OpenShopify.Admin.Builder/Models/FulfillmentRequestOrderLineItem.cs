using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment request order line items.
    /// </summary>
    public partial record FulfillmentRequestOrderLineItem
    {
        /// <summary>
        /// The ID of the fulfillment order line item.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The total number of units to be fulfilled.
        /// </summary>
        [JsonPropertyName("quantity")]
        public long? Quantity { get; set; }

    }
}
