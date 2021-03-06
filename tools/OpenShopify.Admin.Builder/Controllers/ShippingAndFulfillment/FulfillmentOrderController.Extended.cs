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
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task CancelFulfillmentOrder([Required] CancelFulfillmentOrderRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/close.invalid")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task MarkFulfillmentOrderAsIncomplete(long fulfillment_order_id) => throw new NotImplementedException();

    /// <inheritdoc cref="FulfillmentOrderControllerBase.MarkFulfillmentOrderAsIncomplete" />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/close.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public Task MarkFulfillmentOrderAsIncomplete([Required] MarkFulfillmentOrderAsIncompleteRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/move.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task MoveFulfillmentOrderToNewLocation([Required] MoveFulfillmentOrderToNewLocationRequest toNewLocationRequest, long fulfillment_order_id) => throw new NotImplementedException();


    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/open.invalid")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task MarkFulfillmentOrderAsOpen(long fulfillment_order_id) => throw new NotImplementedException();

    /// <inheritdoc cref="FulfillmentOrderControllerBase.MarkFulfillmentOrderAsOpen" />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/open.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public Task MarkFulfillmentOrderAsOpen([Required] MarkFulfillmentOrderAsOpenRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/reschedule.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task RescheduleFulfillAtTimeOfScheduledFulfillmentOrder([Required] RescheduleFulfillAtTimeOfScheduledFulfillmentOrderRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/hold.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task ApplyFulfillmentHoldOnFulfillmentOrder([Required] ApplyFulfillmentHoldOnFulfillmentOrderRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/release_hold.json")]
    [ProducesResponseType(typeof(FulfillmentOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FulfillmentOrderGeneralError), StatusCodes.Status400BadRequest)]
    public override Task ReleaseFulfillmentHoldOnFulfillmentOrder([Required] ReleaseFulfillmentHoldOnFulfillmentOrderRequest request, long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}