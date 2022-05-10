using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CancellationRequestController : CancellationRequestControllerBase
{
    public override Task SendCancellationRequest([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task AcceptCancellationRequest([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task RejectCancellationRequest([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}