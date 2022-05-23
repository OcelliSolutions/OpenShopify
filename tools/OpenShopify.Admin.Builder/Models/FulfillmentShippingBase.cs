
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment request.
    /// </summary>
    public partial record FulfillmentShippingBase
    {
        /// <summary>
        /// An optional message for the fulfillment request.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// A flag indicating whether the customer should be notified. If set to true, an email will be
        /// sent when the fulfillment is created or updated. The default value is false for fulfillments
        /// on any orders created initially through the API. For all other orders, the default value is true.
        /// </summary>
        [JsonPropertyName("notify_customer")]
        public bool? NotifyCustomer { get; set; }

        /// <summary>
        /// If applicable tracking details for the package.
        /// </summary>
        [JsonPropertyName("tracking_info")]
        public TrackingInfo? TrackingInfo { get; set; }

        /// <summary>
        /// The fulfillment order line items to be requested for fulfillment. If left blank, all line items of the fulfillment order are requested for fulfillment.
        /// </summary>
        [JsonPropertyName("line_items_by_fulfillment_order")]
        public ICollection<LineItemsByFulfillmentOrder>? FulfillmentRequestOrderLineItems { get; set; }
    }
}