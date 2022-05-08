using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class LocationsForMoveController : LocationsForMoveControllerBase
{
    public override Task RetrieveListOfLocationsThatFulfillmentOrderCanPotentiallyMoveTo(string fulfillment_order_idPath,
        string? fulfillment_order_idQuery = null)
    {
        throw new NotImplementedException();
    }
}