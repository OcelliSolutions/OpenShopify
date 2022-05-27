using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RequestStatus
{
    [EnumMember(Value = "unsubmitted"), Description("The initial request status for newly-created fulfillment orders. This is the only valid request status for fulfillment orders that aren't assigned to a fulfillment service.")]
    Unsubmitted,
    [EnumMember(Value = "submitted"), Description("The merchant requested fulfillment for this fulfillment order.")]
    Submitted,
    [EnumMember(Value = "accepted"), Description("The fulfillment service accepted the merchant's fulfillment request.")]
    Accepted,
    [EnumMember(Value = "rejected"), Description("The fulfillment service rejected the merchant's fulfillment request.")]
    Rejected,
    [EnumMember(Value = "cancellation_requested"), Description("The merchant requested a cancellation of the fulfillment request for this fulfillment order.")]
    CancellationRequested,
    [EnumMember(Value = "cancellation_accepted"), Description("The fulfillment service accepted the merchant's fulfillment cancellation request.")]
    CancellationAccepted,
    [EnumMember(Value = "cancellation_rejected"), Description("The fulfillment service rejected the merchant's fulfillment cancellation request.")]
    CancellationRejected,
    [EnumMember(Value = "closed"), Description("The fulfillment service closed the fulfillment order without completing it.")]
    Closed

}
