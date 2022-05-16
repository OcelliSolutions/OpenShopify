using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class LocationsForMoveController : ILocationsForMoveController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/locations_for_move.json")]
    public Task RetrieveListOfLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}