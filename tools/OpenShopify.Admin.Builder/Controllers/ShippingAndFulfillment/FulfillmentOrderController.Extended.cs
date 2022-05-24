using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
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
    [ProducesResponseType(typeof(FulfillmentOrderList), StatusCodes.Status200OK)]
    public override Task ListFulfillmentOrdersForSpecificOrder([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_orders/{fulfillment_order_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task GetFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/cancel.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task CancelFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/close.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task MarkFulfillmentOrderAsIncomplete([Required] long fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/move.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task MoveFulfillmentOrderToNewLocation(long fulfillment_order_id, long new_location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/open.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task MarkFulfillmentOrderAsOpen([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/reschedule.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task RescheduleFulfillAtTimeOfScheduledFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/hold.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusOPEN([Required] long fulfillment_order_id, string? notify_merchant = null,
        string? reason = null, string? reason_notes = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/release_hold.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    public override Task ReleaseFulfillmentHoldOnFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}