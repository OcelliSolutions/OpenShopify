using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShopifyPayments;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShopifyPayments)]
[ApiController]
public class DisputeFileUploadController : DisputeFileUploadControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("shopify_payments/disputes/{dispute_id}/dispute_file_uploads.json")]
    [ProducesResponseType(typeof(DisputeFileUploadItem), StatusCodes.Status200OK)]
    public override Task UploadFileToDispute(long dispute_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("shopify_payments/disputes/{dispute_id}/dispute_file_uploads/{dispute_file_upload_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteDisputeEvidenceFile(long dispute_file_upload_id, long dispute_id) => throw new NotImplementedException();
}
