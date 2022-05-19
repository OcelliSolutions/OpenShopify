using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CancellationRequestController : CancellationRequestControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request.json")]
    public override Task SendCancellationRequest(long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request/accept.json")]
    public override Task AcceptCancellationRequest(long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request/reject.json")]
    public override Task RejectCancellationRequest(long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }
}