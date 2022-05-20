using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class DisputeController : DisputeControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/disputes.json")]
    public override Task ListDisputes(string? initiated_at, long? last_id, int? since_id, string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/disputes/{dispute_id:long}.json")]
    public override Task GetDispute([Required] long dispute_id)
    {
        throw new NotImplementedException();
    }
}