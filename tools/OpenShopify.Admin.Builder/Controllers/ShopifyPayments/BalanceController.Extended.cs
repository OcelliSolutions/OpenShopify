using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class BalanceController : BalanceControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/balance.json")]
    [ProducesResponseType(typeof(BalanceItem), StatusCodes.Status200OK)]
    public override Task GetCurrentBalance()
    {
        throw new NotImplementedException();
    }
}