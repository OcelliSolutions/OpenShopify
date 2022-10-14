using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
public partial class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc cref="MetafieldControllerBase.CountResourcesMetafields"/> />
    [HttpGet]
    [Route("pages/{page_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public Task CountMetafieldsAttachedToPage(long? page_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("pages/{page_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafieldForPage([Required] CreateMetafieldForPageRequest request, [Required] long page_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("pages/{page_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldForPage([Required] long page_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("pages/{page_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToPage([Required] long metafield_id, [Required] long page_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("pages/{page_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task ListMetafieldsAttachedToPage([Required] long page_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsAttachedToPage" />
    [HttpGet]
    [Route("pages/{page_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToPage([Required] long page_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("pages/{page_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task
        UpdateMetafieldForPage([Required] UpdateMetafieldForPageRequest request, [Required] long page_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}