using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum OrderFulfillmentStatus
{
    [EnumMember(Value = "fulfilled"), Description("Every line item in the order has been fulfilled.")]
    Fulfilled,
    [EnumMember(Value = "partial"), Description("At least one line item in the order has been fulfilled.")]
    Partial,
    [EnumMember(Value = "restocked"), Description("Every line item in the order has been restocked and the order canceled.")]
    Restocked
}