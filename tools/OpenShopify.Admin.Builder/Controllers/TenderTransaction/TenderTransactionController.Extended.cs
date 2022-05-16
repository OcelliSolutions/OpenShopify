using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.TenderTransaction;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.TenderTransaction)]
[ApiController]
public class TenderTransactionController : ITenderTransactionController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("tender_transactions.json")]
    public Task RetrieveListOfTenderTransactionsAsync(string limit, string? order, string? processed_at, string? processed_at_max,
        string? processed_at_min, string? since_id)
    {
        throw new NotImplementedException();
    }
}