using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductResourceFeedbackController : IProductResourceFeedbackController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/resource_feedback.json")]
    public Task CreateNewProductResourceFeedbackAsync(string product_id, string? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/resource_feedback.json")]
    public Task ReceiveListOfAllProductResourceFeedbacksAsync(string product_id)
    {
        throw new NotImplementedException();
    }
}