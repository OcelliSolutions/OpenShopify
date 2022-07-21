using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum IncoTerm
{
    [EnumMember(Value = "DAP")]
    DeliveredAtPlace,
    [EnumMember(Value = "DDP")]
    DeliveredDutyPaid
}
