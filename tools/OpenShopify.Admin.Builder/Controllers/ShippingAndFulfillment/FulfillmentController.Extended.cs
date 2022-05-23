using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentController : FulfillmentControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments.json")]
    [ProducesResponseType(typeof(FulfillmentList), StatusCodes.Status200OK)]
    public override Task GetFulfillmentsAssociatedWithOrder([Required] long order_id, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, int? limit = null, string? page_info = null, long? since_id = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status201Created)]
    public override Task CreateFulfillment([Required] CreateFulfillmentRequest request, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillments.json")]
    [ProducesResponseType(typeof(FulfillmentList), StatusCodes.Status200OK)]
    public override Task GetFulfillmentsAssociatedWithFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountFulfillmentsAssociatedWithSpecificOrder(long? order_id = null, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task GetFulfillment([Required] long fulfillment_id, [Required] long order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task UpdateFulfillment([Required] UpdateFulfillmentRequest request, [Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status201Created)]
    //TODO: wrong request type
    public override Task CreateFulfillmentForOneOrManyFulfillmentOrders([Required] CreateFulfillmentRequest request)
    {
        throw new NotImplementedException();
    }

    ///TODO: change the request type
    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/update_tracking.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task UpdateTrackingInformationForFulfillment([Required] UpdateFulfillmentRequest request, [Required] long fulfillment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/complete.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task CompleteFulfillment([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/open.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task TransitionFulfillmentFromPendingToOpen([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/cancel.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task CancelFulfillmentForSpecificOrderID([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/cancel.json")]
    [ProducesResponseType(typeof(FulfillmentItem), StatusCodes.Status200OK)]
    public override Task CancelFulfillment([Required] long fulfillment_id)
    {
        throw new NotImplementedException();
    }
}
