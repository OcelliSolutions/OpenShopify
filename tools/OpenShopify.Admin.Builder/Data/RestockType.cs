using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RestockType
{
    [EnumMember(Value = "no_restock"), Description("Refunding these items won't affect inventory. The number of fulfillable units for this line item will remain unchanged. For example, a refund payment can be issued but no items will be refunded or made available for sale again.")]
    NoRestock,
    [EnumMember(Value = "cancel"), Description("The items have not yet been fulfilled. The canceled quantity will be added back to the available count. The number of fulfillable units for this line item will decrease.")]
    Cancel,
    [EnumMember(Value = "return"), Description("The items were already delivered, and will be returned to the merchant. The refunded quantity will be added back to the available count. The number of fulfillable units for this line item will remain unchanged.")]
    Return,
    [EnumMember(Value = "legacy_restock"), Description("The deprecated restock property was used for this refund. These items were made available for sale again. This value is not accepted when creating new refunds.")]
    lLgacyRestock,
}
