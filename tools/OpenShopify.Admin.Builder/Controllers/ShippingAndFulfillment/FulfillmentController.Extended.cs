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
    public override Task RetrieveFulfillmentsAssociatedWithOrder(long order_id, DateTime? created_at_max, DateTime? created_at_min,
        string? fields, int? limit, string? page_info, int? since_id, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments.json")]
    public override Task CreateNewFulfillment(CreateFulfillmentRequest request, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillments.json")]
    public override Task RetrieveFulfillmentsAssociatedWithFulfillmentOrder(long fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfFulfillmentsAssociatedWithSpecificOrder(long order_id, DateTime? created_at_max,
        DateTime? created_at_min, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    public override Task ReceiveSingleFulfillment(long fulfillment_id, long order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}.json")]
    public override Task ModifyExistingFulfillment(UpdateFulfillmentRequest request, long fulfillment_id, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments.json")]
    //TODO: wrong request type
    public override Task CreateFulfillmentForOneOrManyFulfillmentOrders(CreateFulfillmentRequest request)
    {
        throw new NotImplementedException();
    }

    ///TODO: change the request type
    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/update_tracking.json")]
    public override Task UpdateTrackingInformationForFulfillment(UpdateFulfillmentRequest request, long fulfillment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/complete.json")]
    public override Task CompleteFulfillment(long fulfillment_id, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/open.json")]
    public override Task TransitionFulfillmentFromPendingToOpen(long fulfillment_id, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/cancel.json")]
    public override Task CancelFulfillmentForSpecificOrderID(long fulfillment_id, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillments/{fulfillment_id:long}/cancel.json")]
    public override Task CancelFulfillment(long fulfillment_id)
    {
        throw new NotImplementedException();
    }
}
