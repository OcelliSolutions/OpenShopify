using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ResourceFeedbackController : ResourceFeedbackControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("resource_feedback.json")]
    public override Task CreateNewResourceFeedback(ResourceFeedbackItem request, string feedback_generated_at, string messages,
        string state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("resource_feedback.json")]
    public override Task ReceiveListOfAllResourceFeedbacks()
    {
        throw new NotImplementedException();
    }
}
