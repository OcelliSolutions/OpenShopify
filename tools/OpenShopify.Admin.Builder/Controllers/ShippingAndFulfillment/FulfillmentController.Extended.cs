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
    public override Task GetFulfillmentsAssociatedWithOrder([Required] long order_id, DateTime? created_at_max, DateTime? created_at_min,
        string? fields, int? limit, string? page_info, int? since_id, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments.json")]
    public override Task CreateFulfillment([Required] CreateFulfillmentRequest request, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillments.json")]
    public override Task GetFulfillmentsAssociatedWithFulfillmentOrder([Required] long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountFulfillmentsAssociatedWithSpecificOrder([Required] long order_id, DateTime? created_at_max,
        DateTime? created_at_min, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    public override Task GetFulfillment([Required] long fulfillment_id, [Required] long order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    public override Task UpdateFulfillment([Required] UpdateFulfillmentRequest request, [Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments.json")]
    //TODO: wrong request type
    public override Task CreateFulfillmentForOneOrManyFulfillmentOrders([Required] CreateFulfillmentRequest request)
    {
        throw new NotImplementedException();
    }

    ///TODO: change the request type
    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/update_tracking.json")]
    public override Task UpdateTrackingInformationForFulfillment([Required] UpdateFulfillmentRequest request, [Required] long fulfillment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/complete.json")]
    public override Task CompleteFulfillment([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/open.json")]
    public override Task TransitionFulfillmentFromPendingToOpen([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/cancel.json")]
    public override Task CancelFulfillmentForSpecificOrderID([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/cancel.json")]
    public override Task CancelFulfillment([Required] long fulfillment_id)
    {
        throw new NotImplementedException();
    }
}
