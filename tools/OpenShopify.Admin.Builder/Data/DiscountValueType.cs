using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum DiscountValueType
{
    [EnumMember(Value = "fixed_amount")]
    FixedAmount,
    [EnumMember(Value = "percentage")]
    Percentage
}
