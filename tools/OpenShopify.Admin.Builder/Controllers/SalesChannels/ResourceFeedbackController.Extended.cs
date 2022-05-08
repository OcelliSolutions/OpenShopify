using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ResourceFeedbackController : ResourceFeedbackControllerBase
{
    public override Task CreateNewResourcefeedback(string feedback_generated_at, string messages, string state)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveListOfAllResourcefeedbacks()
    {
        throw new NotImplementedException();
    }
}