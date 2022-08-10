using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentStatusRequest
{
    [EnumMember(Value = "shipped"), Description("Show orders that have been shipped. Returns orders with `fulfillment_status` of `fulfilled`.")]
    Shipped,
    [EnumMember(Value = "partial"), Description("Show partially shipped orders.")]
    Partial,
    [EnumMember(Value = "unshipped"), Description("Show orders that have not yet been shipped. Returns orders with `fulfillment_status` of `null`.")]
    Unshipped,
    [EnumMember(Value = "any"), Description("Show orders of any financial status.")]
    Any,
    [EnumMember(Value = "unfulfilled"), Description("Returns orders with `fulfillment_status` of `null` or `partial`.")]
    Unfulfilled
}