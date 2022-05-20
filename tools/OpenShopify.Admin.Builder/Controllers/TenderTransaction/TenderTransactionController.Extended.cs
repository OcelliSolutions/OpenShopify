using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.TenderTransaction;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.TenderTransaction)]
[ApiController]
public class TenderTransactionController : TenderTransactionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("tender_transactions.json")]
    public override Task ListTenderTransactions(int? limit, string? page_info, string? order, string? processed_at, DateTime? processed_at_max,
        DateTime? processed_at_min, int? since_id)
    {
        throw new NotImplementedException();
    }
}