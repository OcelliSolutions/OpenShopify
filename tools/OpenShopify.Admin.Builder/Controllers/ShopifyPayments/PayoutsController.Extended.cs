using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class PayoutsController : PayoutsControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("shopify_payments/payouts.json")]
    [ProducesResponseType(typeof(PayoutList), StatusCodes.Status200OK)]
    public override Task ListPayouts(DateTime? date = null, DateTime? date_max = null, DateTime? date_min = null,
        long? last_id = null, long? since_id = null,
        string? status = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("shopify_payments/payouts/{payout_id:long}.json")]
    [ProducesResponseType(typeof(PayoutItem), StatusCodes.Status200OK)]
    public override Task GetPayout([Required] long payout_id) => throw new NotImplementedException();
}