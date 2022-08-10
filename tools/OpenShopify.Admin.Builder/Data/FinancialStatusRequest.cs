using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

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