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
    public override Task SendFulfillmentRequest([Required] long fulfillment_order_id, string? fulfillment_order_line_items,
        string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/accept.json")]
    public override Task AcceptFulfillmentRequest([Required] long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/reject.json")]
    public override Task RejectFulfillmentRequest([Required] long fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }
}