using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentOrderStatus
{
    [EnumMember(Value = "open"), Description("The fulfillment order is ready for fulfillment.")] 
    Open,
    [EnumMember(Value = "in_progress"), Description("The fulfillment order is being processed.")]
    InProgress,
    [EnumMember(Value = "scheduled"), Description("The fulfillment order is deferred and will be ready for fulfillment after the datetime specified in fulfill_at.")]
    Scheduled,
    [EnumMember(Value = "cancelled"), Description("The fulfillment order has been cancelled by the merchant.")]
    Cancelled,
    [EnumMember(Value = "on_hold"), Description("The fulfillment order is on hold. The fulfillment process can't be initiated until the hold on the fulfillment order is released.")]
    OnHold,
    [EnumMember(Value = "incomplete"), Description("The fulfillment order cannot be completed as requested.")]
    Incomplete,
    [EnumMember(Value = "closed"), Description("The fulfillment order has been completed and closed.")]
    Closed,
}
