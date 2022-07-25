using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class CurrencyController : CurrencyControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("currencies.json")]
    [ProducesResponseType(typeof(CurrencyList), StatusCodes.Status200OK)]
    public override Task ListCurrenciesEnabledOnShop() => throw new NotImplementedException();
}