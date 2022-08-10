using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum OrderStatusRequest
{
    [EnumMember(Value = "open"), Description("Open orders.")]
    Open,
    [EnumMember(Value = "closed"), Description("Closed orders.")]
    Closed,
    [EnumMember(Value = "any"), Description("Orders of any status.")]
    Any
}