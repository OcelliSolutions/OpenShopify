using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentStatus
{
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "error")]
    Error,
    [EnumMember(Value = "failure")]
    Failure,
}