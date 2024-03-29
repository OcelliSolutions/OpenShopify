using System.ComponentModel.DataAnnotations;
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
    [HttpPost]
    [Route("resource_feedback.json")]
    [ProducesResponseType(typeof(ResourceFeedbackItem), StatusCodes.Status202Accepted)]
    public override Task CreateResourceFeedback([Required] CreateResourceFeedbackRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("resource_feedback.json")]
    [ProducesResponseType(typeof(ResourceFeedbackList), StatusCodes.Status200OK)]
    public override Task ListResourceFeedbacks() => throw new NotImplementedException();
}