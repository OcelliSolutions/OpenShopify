using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PriceRuleAllocationMethod
{
    [EnumMember(Value = "each"), Description("The discount is applied to each of the entitled items. For example, for a price rule that takes $15 off, each entitled line item in a checkout will be discounted by $15.")]
    Each,
    [EnumMember(Value = "across"), Description("The calculated discount amount will be applied across the entitled items. For example, for a price rule that takes $15 off, the discount will be applied across all the entitled items.")]
    Across
}