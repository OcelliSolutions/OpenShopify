
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment request.
    /// </summary>
    public partial record FulfillmentRequest
    {
        /// <summary>
        /// An optional message for the fulfillment request.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The fulfillment order line items to be requested for fulfillment. If left blank, all line items of the fulfillment order are requested for fulfillment.
        /// </summary>
        [JsonPropertyName("fulfillment_order_line_items")]
        public ICollection<FulfillmentOrderLineItem>? FulfillmentRequestOrderLineItems { get; set; }
    }
}