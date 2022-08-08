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
public enum FinancialStatusRequest
{
    [EnumMember(Value = "pending"), Description("Show only pending orders.")]
    Pending,
    [EnumMember(Value = "authorized"), Description("Show only authorized orders.")]
    Authorized,
    [EnumMember(Value = "partially_paid"), Description("Show only partially paid orders.")]
    PartiallyPaid,
    [EnumMember(Value = "paid"), Description("Show only paid orders.")]
    Paid,
    [EnumMember(Value = "partially_refunded"), Description("Show only partially refunded orders.")]
    PartiallyRefunded,
    [EnumMember(Value = "refunded"), Description("Show only refunded orders.")]
    Refunded,
    [EnumMember(Value = "voided"), Description("Show only voided orders.")]
    Voided,
    [EnumMember(Value = "any"), Description("Show orders of any financial status.")]
    Any,
    [EnumMember(Value = "unpaid"), Description("Show authorized and partially paid orders.")]
    Unpaid
}

public enum OrderStatusRequest
{
    [EnumMember(Value = "open"), Description("Open orders.")]
    Open,
    [EnumMember(Value = "closed"), Description("Closed orders.")]
    Closed,
    [EnumMember(Value = "any"), Description("Orders of any status.")]
    Any
}
