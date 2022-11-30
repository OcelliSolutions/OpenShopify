using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PriceRuleValueType
{
    [EnumMember(Value = "fixed_amount"), Description("Applies a discount of `value` as a unit of the store's currency. For example, if `value` is -30 and the store's currency is USD, then $30 USD is deducted when the discount is applied.")]
    FixedAmount,
    [EnumMember(Value = "percentage"), Description("Applies a percentage discount of `value`. For example, if `value` is -30, then 30% will be deducted when the discount is applied")]
    Percentage
}