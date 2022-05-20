using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class AbandonedCheckoutsController : AbandonedCheckoutsControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("checkouts.json")]
    public override Task ListAbandonedCheckouts(DateTime? created_at_max, DateTime? created_at_min, int? limit, string? page_info,
        int? since_id, string status, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }
}