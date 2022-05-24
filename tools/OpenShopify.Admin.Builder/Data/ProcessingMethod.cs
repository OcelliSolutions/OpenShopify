using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ProcessingMethod
{
    [EnumMember(Value = "checkout"), Description("The order was processed using the Shopify checkout.")]
    Checkout,
    [EnumMember(Value = "direct"), Description("The order was processed using a direct payment provider.")]
    Direct,
    [EnumMember(Value = "manual"), Description("The order was processed using a manual payment method.")]
    Manual,
    [EnumMember(Value = "offsite"), Description("The order was processed by an external payment provider to the Shopify checkout.")]
    Offsite,
    [EnumMember(Value = "express"), Description("The order was processed using PayPal Express Checkout.")]
    Express,
    [EnumMember(Value = "free"), Description("The order was processed as a free order using a discount code.")]
    Free
}
