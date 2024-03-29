using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CancellationRequestController : CancellationRequestControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request.json")]
    [ProducesResponseType(typeof(FulfillmentOrderWithOriginItem), StatusCodes.Status200OK)]
    public override Task SendCancellationRequest([Required] SendCancellationRequestRequest request,
        long fulfillment_order_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request/accept.json")]
    [ProducesResponseType(typeof(FulfillmentOrderWithOriginItem), StatusCodes.Status200OK)]
    public override Task AcceptCancellationRequest([Required] AcceptCancellationRequestRequest request,
        long fulfillment_order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/cancellation_request/reject.json")]
    [ProducesResponseType(typeof(FulfillmentOrderWithOriginItem), StatusCodes.Status200OK)]
    public override Task RejectCancellationRequest([Required] RejectCancellationRequestRequest request,
        long fulfillment_order_id) => throw new NotImplementedException();
}