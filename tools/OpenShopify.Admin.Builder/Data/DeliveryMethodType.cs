using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum DeliveryMethodType
{
    [EnumMember(Value = "local"), Description("A delivery to a customer's doorstep.")]
    Local,
    [EnumMember(Value = "none"), Description("No delivery method.")]
    None,
    [EnumMember(Value = "pick_up"), Description("A delivery that a customer picks up at your retail store, curbside, or any location that you choose.")]
    PickUp,
    [EnumMember(Value = "retail"), Description("Items delivered immediately in a retail store.")]
    Retail,
    [EnumMember(Value = "shipping"), Description("A delivery to a customer using a shipping carrier.")]
    Shipping
}
