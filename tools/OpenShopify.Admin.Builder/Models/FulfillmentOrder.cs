using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record FulfillmentOrder
    {
        /// <summary>
        /// Destination for the fulfillment.
        /// </summary>
        [JsonPropertyName("destination")]
        public FulfillmentOrderDestination? FulfillmentOrderDestination { get; set; }

        /// <summary>
        /// Represents line items belonging to a fulfillment order:
        /// </summary>
        [JsonPropertyName("line_items")]
        public IEnumerable<FulfillmentOrderLineItem>? FulfillmentOrderLineItems { get; set; }

        /// <summary>
        /// Followings actions can be performed on this fulfillment order.
        /// </summary>
        [JsonPropertyName("outgoing_requests")]
        public IEnumerable<OutgoingRequest>? OutgoingRequests { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.MerchantRequests"/>
        [JsonPropertyName("merchant_requests")]
        public new IEnumerable<MerchantRequest>? MerchantRequests { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.AssignedLocation"/>
        [JsonPropertyName("assigned_location")]
        public new AssignedLocation? AssignedLocation { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.DeliveryMethod"/>
        [JsonPropertyName("delivery_method")]
        public new DeliveryMethod? DeliveryMethod { get; set; }
    }
}