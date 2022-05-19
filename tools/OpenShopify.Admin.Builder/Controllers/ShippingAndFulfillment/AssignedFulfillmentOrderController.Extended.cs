using Microsoft.AspNetCore.Mvc;
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
    public override Task RetrieveListOfFulfillmentOrdersOnShopForSpecificApp(string? assignment_status, long? location_ids)
    {
        throw new NotImplementedException();
    }
}