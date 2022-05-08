using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class BalanceController : BalanceControllerBase
{
    public override Task ReturnTheCurrentBalance()
    {
        throw new NotImplementedException();
    }
}