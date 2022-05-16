using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class AssignedFulfillmentOrderController : IAssignedFulfillmentOrderController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("assigned_fulfillment_orders.json")]
    public Task RetrieveListOfFulfillmentOrdersOnShopForSpecificAppAsync(string? assignment_status, string? location_ids)
    {
        throw new NotImplementedException();
    }
}