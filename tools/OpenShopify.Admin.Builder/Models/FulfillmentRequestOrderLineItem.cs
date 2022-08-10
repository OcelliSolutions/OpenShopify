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

    public partial record FulfillmentOrderWithOriginItem
    {
        [JsonPropertyName("fulfillment_order")]
        public FulfillmentOrderWithOrigin FulfillmentOrder { get; set; } = null!;
    }
    public partial record SendFulfillmentRequestItem
    {
        [JsonPropertyName("original_fulfillment_order")]
        public FulfillmentOrderWithOrigin OriginalFulfillmentOrder { get; set; } = null!;

        [JsonPropertyName("submitted_fulfillment_order")]
        public FulfillmentOrderWithOrigin SubmittedFulfillmentOrder { get; set; } = null!;

        [JsonPropertyName("unsubmitted_fulfillment_order")]
        public FulfillmentOrderWithOrigin? UnsubmittedFulfillmentOrder { get; set; }
    }

    public record FulfillmentOrderWithOrigin : FulfillmentOrder
    {
        [JsonPropertyName("origin")]
        public new AssignedLocation? AssignedLocation { get; set; }
    }


    public partial record AcceptFulfillmentRequestItem
    {
        [JsonPropertyName("fulfillment_order")]
        public FulfillmentOrderWithOrigin FulfillmentOrder { get; set; } = null!;
    }
    public partial record RejectFulfillmentRequestItem
    {
        [JsonPropertyName("fulfillment_order")]
        public FulfillmentOrderWithOrigin FulfillmentOrder { get; set; } = null!;
    }
}
