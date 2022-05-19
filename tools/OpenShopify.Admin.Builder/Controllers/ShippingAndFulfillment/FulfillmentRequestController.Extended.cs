using Microsoft.AspNetCore.Mvc;
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
    public override Task SendFulfillmentRequest(long fulfillment_order_id, string? fulfillment_order_line_items = null,
        string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/accept.json")]
    public override Task AcceptFulfillmentRequest(long fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_orders/{fulfillment_order_id:long}/fulfillment_request/reject.json")]
    public override Task RejectFulfillmentRequest(long fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}