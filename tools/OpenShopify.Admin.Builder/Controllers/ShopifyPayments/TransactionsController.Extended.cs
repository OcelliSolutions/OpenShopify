using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class TransactionsController : TransactionsControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/balance/transactions.json")]
    public override Task ListBalanceTransactions(long payout_id, long? last_id = null, string? payout_status = null, long? since_id = null,
        bool? test = null)
    {
        throw new NotImplementedException();
    }
}