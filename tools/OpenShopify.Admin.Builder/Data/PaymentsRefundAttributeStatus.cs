using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PaymentsRefundAttributeStatus
{
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "error")]
    Error
}
