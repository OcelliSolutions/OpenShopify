using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentOrderController : FulfillmentOrderControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillment_orders.json")]
    public override Task ListFulfillmentOrdersForSpecificOrder(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_orders/{fulfillment_order_id:long}.json")]
    public override Task GetSpecificFulfillmentOrder(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/cancel.json")]
    public override Task CancelFulfillmentOrder(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/close.json")]
    public override Task MarkFulfillmentOrderAsIncomplete(long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/move.json")]
    public override Task MoveFulfillmentOrderToNewLocation(long fulfillment_order_id, long? new_location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/open.json")]
    public override Task MarkFulfillmentOrderAsOpen(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/reschedule.json")]
    public override Task RescheduleFulfillAtTimeOfScheduledFulfillmentOrder(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/hold.json")]
    public override Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusOPEN(long fulfillment_order_id, string? notify_merchant,
        string? reason, string? reason_notes)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/release_hold.json")]
    public override Task ReleaseFulfillmentHoldOnFulfillmentOrder(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}