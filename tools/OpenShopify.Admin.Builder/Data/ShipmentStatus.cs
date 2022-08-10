using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ShipmentStatus
{
    [EnumMember(Value = "label_printed")]
    LabelPrinted,
    [EnumMember(Value = "label_purchased")]
    LabelPurchased,
    [EnumMember(Value = "attempted_delivery")]
    AttemptedDelivery,
    [EnumMember(Value = "ready_for_pickup")]
    ReadyForPickup,
    [EnumMember(Value = "confirmed")]
    Confirmed,
    [EnumMember(Value = "in_transit")]
    InTransit,
    [EnumMember(Value = "out_for_delivery")]
    OutForDelivery,
    [EnumMember(Value = "delivered")]
    Delivered,
    [EnumMember(Value = "failure")]
    Failure
}

