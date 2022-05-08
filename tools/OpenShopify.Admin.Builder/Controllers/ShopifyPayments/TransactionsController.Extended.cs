using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class TransactionsController : TransactionsControllerBase
{
    public override Task ReturnListOfAllBalanceTransactions(string? last_id = null, string? payout_id = null, string? payout_status = null,
        string? since_id = null, string? test = null)
    {
        throw new NotImplementedException();
    }
}