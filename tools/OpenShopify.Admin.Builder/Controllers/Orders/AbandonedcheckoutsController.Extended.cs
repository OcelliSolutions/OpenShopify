using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class AbandonedCheckoutsController : AbandonedCheckoutsControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts.json")]
    [ProducesResponseType(typeof(AbandonedCheckoutList), StatusCodes.Status200OK)]
    public override Task ListAbandonedCheckouts(DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null,
        int? limit = null, string? page_info = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();
}