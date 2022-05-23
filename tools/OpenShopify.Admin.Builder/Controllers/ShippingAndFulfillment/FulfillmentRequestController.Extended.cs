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
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request.json")]
    [ProducesResponseType(typeof(FulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task SendFulfillmentRequest([Required] long fulfillment_order_id, string? fulfillment_order_line_items = null,
        string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/accept.json")]
    [ProducesResponseType(typeof(FulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task AcceptFulfillmentRequest([Required] long fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/reject.json")]
    [ProducesResponseType(typeof(FulfillmentRequestItem), StatusCodes.Status200OK)]
    public override Task RejectFulfillmentRequest([Required] long fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}