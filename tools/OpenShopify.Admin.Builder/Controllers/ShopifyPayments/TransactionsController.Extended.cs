using Microsoft.AspNetCore.Mvc;
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
    public override Task ReturnListOfAllBalanceTransactions(long? last_id, long? payout_id, string? payout_status,
        int? since_id, string? test)
    {
        throw new NotImplementedException();
    }
}