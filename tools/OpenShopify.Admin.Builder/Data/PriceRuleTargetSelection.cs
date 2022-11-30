using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PriceRuleTargetSelection
{
    [EnumMember(Value = "all"), Description("The price rule applies the discount to all line items in the checkout.")]
    All,
    [EnumMember(Value = "entitled"), Description("The price rule applies the discount to selected entitlements only")]
    Entitled
}