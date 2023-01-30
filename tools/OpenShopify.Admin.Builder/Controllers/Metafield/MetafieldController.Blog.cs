using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
public partial class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc cref="MetafieldControllerBase.CountMetafieldsAttachedToShopResource" />
    [HttpGet]
    [Route("blogs/{blog_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public Task CountMetafieldsAttachedToBlog([Required] long? blog_id = null) => throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.CreateMetafield" />
    [HttpPost]
    [Route("blogs/{blog_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public Task CreateMetafieldForBlog([Required] CreateMetafieldForBlogRequest request, [Required] long blog_id) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.DeleteMetafield" />
    [HttpDelete]
    [Route("blogs/{blog_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteMetafieldForBlog([Required] long blog_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.GetMetafield" />
    [HttpGet]
    [Route("blogs/{blog_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public Task GetMetafieldAttachedToBlog([Required] long metafield_id, [Required] long blog_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsFromResourcesEndpoint" />
    [HttpGet]
    [Route("blogs/{blog_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToBlog(long blog_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.UpdateMetafield" />
    [HttpPut]
    [Route("blogs/{blog_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public Task
        UpdateMetafieldForBlog([Required] UpdateMetafieldForBlogRequest request, [Required] long blog_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}