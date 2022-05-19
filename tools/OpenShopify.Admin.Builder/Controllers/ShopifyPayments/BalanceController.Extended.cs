using Microsoft.AspNetCore.Mvc;
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
    public override Task ReturnCurrentBalance()
    {
        throw new NotImplementedException();
    }
}