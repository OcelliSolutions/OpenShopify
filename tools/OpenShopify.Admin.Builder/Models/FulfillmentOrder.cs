using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

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

        /// <inheritdoc cref="FulfillmentOrderOrig.FulfillmentHolds"/>
        [JsonPropertyName("fulfillment_holds")]
        public new IEnumerable<FulfillmentHold>? FulfillmentHolds { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.RequestStatus"/>
        [JsonPropertyName("request_status"), Required]
        public new FulfillmentOrderRequestStatus RequestStatus { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.Status"/>
        [JsonPropertyName("status"), Required]
        public new FulfillmentOrderStatus Status { get; set; }

        /// <inheritdoc cref="FulfillmentOrderOrig.SupportedActions"/>
        [JsonPropertyName("supported_actions"), Required]
        public new IEnumerable<Data.FulfillmentOrderActions> SupportedActions { get; set; } = null!;

        /// <inheritdoc cref="FulfillmentOrderOrig.InternationalDuties"/>
        [JsonPropertyName("international_duties")]
        public new InternationalDuties? InternationalDuties { get; set; } = default!;
    }
}