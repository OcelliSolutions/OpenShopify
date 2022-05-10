using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentRequestController : FulfillmentRequestControllerBase
{
    public override Task SendFulfillmentRequest([FromRoute] string fulfillment_order_id, string? fulfillment_order_line_items = null,
        string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task AcceptFulfillmentRequest([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task RejectFulfillmentRequest([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}