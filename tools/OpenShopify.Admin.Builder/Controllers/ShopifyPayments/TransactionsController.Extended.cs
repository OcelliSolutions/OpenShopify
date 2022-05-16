using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class TransactionsController : ITransactionsController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/balance/transactions.json")]
    public Task ReturnListOfAllBalanceTransactionsAsync(string? last_id, string? payout_id, string? payout_status,
        string? since_id, string? test)
    {
        throw new NotImplementedException();
    }
}