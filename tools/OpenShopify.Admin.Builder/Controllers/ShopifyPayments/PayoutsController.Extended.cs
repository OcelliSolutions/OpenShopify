using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class PayoutsController : PayoutsControllerBase
{
    public override Task ReturnListOfAllPayouts(string? date = null, string? date_max = null, string? date_min = null,
        string? last_id = null, string? since_id = null, string? status = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReturnSinglePayout(string payout_id)
    {
        throw new NotImplementedException();
    }
}