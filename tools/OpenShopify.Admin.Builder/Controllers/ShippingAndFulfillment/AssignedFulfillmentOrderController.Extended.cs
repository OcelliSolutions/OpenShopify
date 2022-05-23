using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class AssignedFulfillmentOrderController : AssignedFulfillmentOrderControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("assigned_fulfillment_orders.json")]
    [ProducesResponseType(typeof(AssignedFulfillmentOrderList), StatusCodes.Status200OK)]
    public override Task ListFulfillmentOrdersOnShopForSpecificApp(string? assignment_status = null, string? location_ids = null)
    {
        throw new NotImplementedException();
    }
}