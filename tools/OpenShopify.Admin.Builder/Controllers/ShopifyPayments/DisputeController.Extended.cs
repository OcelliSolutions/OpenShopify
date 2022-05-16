using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class DisputeController : IDisputeController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/disputes.json")]
    public Task ReturnListOfAllDisputesAsync(string? initiated_at, string? last_id, string? since_id, string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/disputes/{dispute_id}.json")]
    public Task ReturnSingleDisputeAsync(string dispute_id)
    {
        throw new NotImplementedException();
    }
}