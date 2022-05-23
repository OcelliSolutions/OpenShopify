using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
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
    [ProducesResponseType(typeof(DisputeList), StatusCodes.Status200OK)]
    public override Task ListDisputes(string? initiated_at = null, long? last_id = null, long? since_id = null, string? status = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("shopify_payments/disputes/{dispute_id:long}.json")]
    [ProducesResponseType(typeof(DisputeItem), StatusCodes.Status200OK)]
    public override Task GetDispute([Required] long dispute_id)
    {
        throw new NotImplementedException();
    }
}