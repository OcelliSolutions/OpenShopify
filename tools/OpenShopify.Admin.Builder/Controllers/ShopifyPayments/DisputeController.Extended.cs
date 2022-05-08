using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class DisputeController : DisputeControllerBase
{
    public override Task ReturnListOfAllDisputes(string? initiated_at = null, string? last_id = null, string? since_id = null,
        string? status = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReturnSingleDispute(string dispute_id)
    {
        throw new NotImplementedException();
    }
}