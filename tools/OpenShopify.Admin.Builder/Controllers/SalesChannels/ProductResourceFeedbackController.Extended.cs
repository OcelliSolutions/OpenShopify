using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductResourceFeedbackController : ProductResourceFeedbackControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/resource_feedback.json")]
    public override Task CreateNewProductResourceFeedback(CreateProductResourceFeedbackRequest request, long product_id, string? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/resource_feedback.json")]
    public override Task ReceiveListOfAllProductResourceFeedbacks(long product_id)
    {
        throw new NotImplementedException();
    }
}