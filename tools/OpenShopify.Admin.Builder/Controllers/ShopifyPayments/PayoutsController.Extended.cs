using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class PayoutsController : PayoutsControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/payouts.json")]
    public override Task ReturnListOfAllPayouts(DateTime? date, DateTime? date_max, DateTime? date_min, long? last_id, int? since_id,
        string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/payouts/{payout_id:long}.json")]
    public override Task ReturnSinglePayout(long payout_id)
    {
        throw new NotImplementedException();
    }
}