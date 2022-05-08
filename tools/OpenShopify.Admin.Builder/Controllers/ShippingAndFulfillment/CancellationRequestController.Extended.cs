using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CancellationRequestController : CancellationRequestControllerBase
{
    public override Task SendCancellationRequest(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task AcceptCancellationRequest(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task RejectCancellationRequest(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}