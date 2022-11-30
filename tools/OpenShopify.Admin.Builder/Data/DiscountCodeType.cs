using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum DiscountCodeType
{
    [EnumMember(Value = "percentage")]
    Percentage,
    [EnumMember(Value = "shipping")]
    Shipping,
    [EnumMember(Value = "fixed_amount")]
    FixedAmount,
    [EnumMember(Value = "none")]
    None
}