using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class PayoutsController : IPayoutsController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/payouts.json")]
    public Task ReturnListOfAllPayoutsAsync(string? date, string? date_max, string? date_min, string? last_id, string? since_id,
        string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/payouts/{payout_id}.json")]
    public Task ReturnSinglePayoutAsync(string payout_id)
    {
        throw new NotImplementedException();
    }
}