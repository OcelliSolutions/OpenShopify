using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ShopController : ShopControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shop.json")]
    public override Task GetShopsConfiguration(string? fields = null)
    {
        throw new NotImplementedException();
    }
}