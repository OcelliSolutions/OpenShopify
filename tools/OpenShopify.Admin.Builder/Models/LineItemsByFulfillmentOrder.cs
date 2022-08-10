
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record LineItemsByFulfillmentOrder
    {
        /// <summary>
        /// The ID of the fulfillment order associated with this line item.
        /// </summary>
        [JsonPropertyName("fulfillment_order_id")]
        public long? FulfillmentOrderId { get; set; }

        /// <summary>
        /// The fulfillment order line items to be requested for fulfillment. If left blank, all line items of the fulfillment order are requested for fulfillment.
        /// </summary>
        [JsonPropertyName("fulfillment_order_line_items")]
        public ICollection<FulfillmentRequestOrderLineItem>? FulfillmentRequestOrderLineItems { get; set; }
    }
}
