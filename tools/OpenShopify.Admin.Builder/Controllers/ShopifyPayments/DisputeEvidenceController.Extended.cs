using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class DisputeEvidenceController : DisputeEvidenceControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("shopify_payments/disputes/{dispute_id:long}/dispute_evidences.json")]
    [ProducesResponseType(typeof(DisputeEvidenceItem), StatusCodes.Status200OK)]
    public override Task GetEvidenceAssociatedWithDispute(long dispute_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("shopify_payments/disputes/{dispute_id}/dispute_evidences.json")]
    [ProducesResponseType(typeof(DisputeList), StatusCodes.Status200OK)]
    public override Task UpdateDisputeEvidence(UpdateDisputeEvidenceRequest request, long dispute_id) => throw new NotImplementedException();
}
