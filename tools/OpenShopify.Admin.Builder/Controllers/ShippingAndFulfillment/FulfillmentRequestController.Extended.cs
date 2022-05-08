using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentRequestController : FulfillmentRequestControllerBase
{
    public override Task SendFulfillmentRequest(string fulfillment_order_id, string? fulfillment_order_line_items = null,
        string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task AcceptFulfillmentRequest(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task RejectFulfillmentRequest(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }
}