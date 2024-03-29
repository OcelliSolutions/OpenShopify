using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentRequestController : FulfillmentRequestControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request.json")]
    [ProducesResponseType(typeof(SendFulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task SendFulfillmentRequest([Required] SendFulfillmentRequestRequest request,
        long fulfillment_order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/accept.json")]
    [ProducesResponseType(typeof(AcceptFulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task AcceptFulfillmentRequest([Required] AcceptFulfillmentRequestRequest request,
        long fulfillment_order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/reject.json")]
    [ProducesResponseType(typeof(RejectFulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task RejectFulfillmentRequest([Required] RejectFulfillmentRequestRequest request,
        long fulfillment_order_id) => throw new NotImplementedException();
}