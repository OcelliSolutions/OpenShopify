using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RefundReason
{
    [EnumMember(Value = "customer")]
    Customer,
    [EnumMember(Value = "inventory")]
    Inventory,
    [EnumMember(Value = "fraud")]
    Fraud,
    [EnumMember(Value = "declined")]
    Declined,
    [EnumMember(Value = "other")]
    Other
}
