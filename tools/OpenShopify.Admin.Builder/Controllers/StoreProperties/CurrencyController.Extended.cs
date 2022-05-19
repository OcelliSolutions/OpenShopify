using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class CurrencyController : CurrencyControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("currencies.json")]
    [ProducesResponseType(typeof(CurrencyList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfCurrenciesEnabledOnShop()
    {
        throw new NotImplementedException();
    }
}