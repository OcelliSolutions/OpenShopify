using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentAssignmentStatus
{
    [EnumMember(Value = "cancellation_requested"), Description("Fulfillment orders for which the merchant has requested cancellation of the previously accepted fulfillment request.")]
    CancellationRequested,
    [EnumMember(Value = "fulfillment_requested"), Description("Fulfillment orders for which the merchant has requested fulfillment.")]
    FulfillmentRequested,
    [EnumMember(Value = "fulfillment_accepted"), Description("Fulfillment orders for which the merchant's fulfillment request has been accepted. Any number of fulfillments can be created on these fulfillment orders to completely fulfill the requested items.")]
    FulfillmentAccepted
}
