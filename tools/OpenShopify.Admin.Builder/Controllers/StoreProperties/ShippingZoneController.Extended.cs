using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ShippingZoneController : ShippingZoneControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shipping_zones.json")]
    public override Task ReceiveListOfAllShippingZones(string? fields)
    {
        throw new NotImplementedException();
    }
}