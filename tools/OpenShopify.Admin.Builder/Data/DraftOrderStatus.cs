using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum DraftOrderStatus
{
    [EnumMember(Value = "open"), Description("Draft order is open.")]
    Open,
    [EnumMember(Value = "invoice_sent"), Description("Invoice has been sent for the draft order.")]
    InvoiceSent,
    [EnumMember(Value = "completed"), Description("Draft order has been completed and turned into an order.")]
    Completed,
}