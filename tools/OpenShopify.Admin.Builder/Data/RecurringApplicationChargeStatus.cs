using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RecurringApplicationChargeStatus
{
    [EnumMember(Value = "pending")]
    Pending,
    [Obsolete("Removed in version 2021-01"), EnumMember(Value = "accepted")]
    Accepted,
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "declined")]
    Declined,
    [EnumMember(Value = "expired")]
    Expired,
    [EnumMember(Value = "frozen")]
    Frozen,
    [EnumMember(Value = "cancelled")]
    Cancelled
}
