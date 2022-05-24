using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum CancelReason
{
    [EnumMember(Value = "customer"), Description("The customer canceled the order.")]
    Customer,
    [EnumMember(Value = "customer"), Description("The order was fraudulent.")]
    Fraud,
    [EnumMember(Value = "inventory"), Description("Items in the order were not in inventory.")]
    Inventory,
    [EnumMember(Value = "declined"), Description("The payment was declined.")]
    Declined,
    [EnumMember(Value = "other"), Description("A reason not in this list.")]
    Other
}
