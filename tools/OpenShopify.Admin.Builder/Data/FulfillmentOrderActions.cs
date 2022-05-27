using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentOrderActions
{
    [EnumMember(Value = "create_fulfillment")]
    CreateFulfillment,
    [EnumMember(Value = "request_fulfillment")]
    RequestFulfillment,
    [EnumMember(Value = "cancel_fulfillment_order")]
    CancelFulfillmentOrder,
    [EnumMember(Value = "request_cancellation")]
    RequestCancellation,
    [EnumMember(Value = "release_hold")]
    ReleaseHold,
    [EnumMember(Value = "mark_as_open")]
    MarkAsOpen,
    [EnumMember(Value = "hold")]
    Hold
}
