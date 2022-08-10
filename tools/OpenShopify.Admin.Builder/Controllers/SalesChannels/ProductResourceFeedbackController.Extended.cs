using System.ComponentModel.DataAnnotations;
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
    [HttpPost]
    [Route("products/{product_id:long}/resource_feedback.json")]
    [ProducesResponseType(typeof(ProductResourceFeedbackItem), StatusCodes.Status201Created)]
    public override Task CreateProductResourceFeedback([Required] CreateProductResourceFeedbackRequest request,
        [Required] long product_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("products/{product_id:long}/resource_feedback.json")]
    [ProducesResponseType(typeof(ProductResourceFeedbackList), StatusCodes.Status200OK)]
    public override Task ListProductResourceFeedbacks([Required] long product_id) =>
        throw new NotImplementedException();
}