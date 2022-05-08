using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class AbandonedCheckoutsController : AbandonedCheckoutsControllerBase
{
    public override Task RetrieveListOfAbandonedCheckouts(string? created_at_max = null, string? created_at_min = null,
        string? limit = "50", string? since_id = null, string? status = "open", string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }
}