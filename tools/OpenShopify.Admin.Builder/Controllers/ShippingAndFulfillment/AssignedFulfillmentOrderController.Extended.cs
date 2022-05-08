using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class AssignedFulfillmentOrderController : AssignedFulfillmentOrderControllerBase
{
    public override Task RetrieveListOfFulfillmentOrdersOnShopForSpecificApp(string? assignment_status = null, string? location_ids = null)
    {
        throw new NotImplementedException();
    }
}