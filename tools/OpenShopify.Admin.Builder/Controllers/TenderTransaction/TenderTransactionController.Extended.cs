using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.TenderTransaction;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.TenderTransaction)]
[ApiController]
public class TenderTransactionController : TenderTransactionControllerBase
{
    public override Task RetrieveListOfTenderTransactions(string? limit = "50", string? order = null, string? processed_at = null,
        string? processed_at_max = null, string? processed_at_min = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }
}