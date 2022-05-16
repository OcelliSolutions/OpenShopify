using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class AbandonedCheckoutsController : IAbandonedCheckoutsController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("checkouts.json")]
    public Task RetrieveListOfAbandonedCheckoutsAsync(string? created_at_max, string? created_at_min, string limit,
        string? since_id, string status, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }
}