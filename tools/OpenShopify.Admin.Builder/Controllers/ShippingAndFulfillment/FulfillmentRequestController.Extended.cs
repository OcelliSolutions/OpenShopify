using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentRequestController : IFulfillmentRequestController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/fulfillment_request.json")]
    public Task SendFulfillmentRequestAsync(string fulfillment_order_id, string? fulfillment_order_line_items = null,
        string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/fulfillment_request/accept.json")]
    public Task AcceptFulfillmentRequestAsync(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/fulfillment_request/reject.json")]
    public Task RejectFulfillmentRequestAsync(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}