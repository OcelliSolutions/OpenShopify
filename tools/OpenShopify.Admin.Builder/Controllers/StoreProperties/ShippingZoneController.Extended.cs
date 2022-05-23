using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
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
    public override Task ListShippingZones(string? fields = null)
    {
        throw new NotImplementedException();
    }
}