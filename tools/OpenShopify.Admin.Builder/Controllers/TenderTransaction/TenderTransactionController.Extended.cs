using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
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
    [ProducesResponseType(typeof(TenderTransactionList), StatusCodes.Status200OK)]
    public override Task ListTenderTransactions(int? limit = null, string? page_info = null, string? order = null,
        DateTimeOffset? processed_at = null, DateTimeOffset? processed_at_max = null,
        DateTimeOffset? processed_at_min = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }
}