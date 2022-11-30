using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PriceRuleTargetType
{
    [EnumMember(Value = "line_item"), Description("The price rule applies to the cart's line items.")]
    LineItem,
    [EnumMember(Value = "shipping_line"), Description("The price rule applies to the cart's shipping lines")]
    ShippingLine
}