using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentHoldReason
{
    [EnumMember(Value = "awaiting_payment"), Description("The fulfillment hold is applied because payment is pending.")]
    AwaitingPayment,
    [EnumMember(Value = "high_risk_of_fraud"), Description("The fulfillment hold is applied because of a high risk of fraud.")]
    HighRiskOfFraud,
    [EnumMember(Value = "incorrect_address"), Description("The fulfillment hold is applied because of an incorrect address.")]
    IncorrectAddress,
    [EnumMember(Value = "inventory_out_of_stock"), Description("The fulfillment hold is applied because inventory is out of stock.")]
    InventoryOutOfStock,
    [EnumMember(Value = "other"), Description("The fulfillment hold is applied for any other reason.")]
    Other
}
