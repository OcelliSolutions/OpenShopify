using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FinancialStatus
{
    [EnumMember(Value = "pending"), Description("The payments are pending. Payment might fail in this state. Check again to confirm whether the payments have been paid successfully.")]
    Pending,
    [EnumMember(Value = "authorized"), Description("The payments have been authorized.")]
    Authorized,
    [EnumMember(Value = "partially_paid"), Description("The order has been partially paid.")]
    PartiallyPaid,
    [EnumMember(Value = "paid"), Description("The payments have been paid.")]
    Paid,
    [EnumMember(Value = "partially_refunded"), Description("The payments have been partially refunded.")]
    PartiallyRefunded,
    [EnumMember(Value = "refunded"), Description("The payments have been refunded.")]
    Refunded,
    [EnumMember(Value = "voided"), Description("The payments have been voided.")]
    Voided
}