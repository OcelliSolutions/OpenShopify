using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CancellationRequestController : ICancellationRequestController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/cancellation_request.json")]
    public Task SendCancellationRequestAsync(string fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/cancellation_request/accept.json")]
    public Task AcceptCancellationRequestAsync(string fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/cancellation_request/reject.json")]
    public Task RejectCancellationRequestAsync(string fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }
}