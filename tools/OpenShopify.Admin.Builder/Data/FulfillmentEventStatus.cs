using System.ComponentModel;
using System.Runtime.Serialization;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Data;

/// <inheritdoc cref="FulfillmentEventOrig.Status"/>
public enum FulfillmentEventStatus
{
    [EnumMember(Value = "label_printed"), Description("A label for the shipment was purchased and printed.")]
    LabelPrinted,
    [EnumMember(Value = "label_purchased"), Description("A label for the shipment was purchased, but not printed.")]
    LabelPurchased,
    [EnumMember(Value = "attempted_delivery"), Description("Delivery of the shipment was attempted, but unable to be completed.")]
    AttemptedDelivery,
    [EnumMember(Value = "ready_for_pickup"), Description("The shipment is ready for pickup at a shipping depot.")]
    ReadyForPickup,
    [EnumMember(Value = "picked_up"), Description("The fulfillment was successfully picked up.")]
    PickedUp,
    [EnumMember(Value = "confirmed"), Description("The carrier is aware of the shipment, but hasn't received it yet.")]
    Confirmed,
    [EnumMember(Value = "in_transit"), Description("The shipment is being transported between shipping facilities on the way to its destination.")]
    InTransit,
    [EnumMember(Value = "out_for_delivery"), Description("The shipment is being delivered to its final destination.")]
    OutForDelivery,
    [EnumMember(Value = "delivered"), Description("The shipment was successfully delivered.")]
    Delivered,
    [EnumMember(Value = "failure"), Description("Something went wrong when pulling tracking information for the shipment, such as the tracking number was invalid or the shipment was canceled.")]
    Failure
}
