using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
public partial class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("collections/{collection_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMetafieldsAttachedToCollection(long? collection_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("collections/{collection_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafieldForCollection([Required] CreateMetafieldForCollectionRequest request, [Required] long collection_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("collections/{collection_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldForCollection([Required] long collection_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("collections/{collection_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToCollection([Required] long metafield_id, [Required] long collection_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("collections/{collection_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public override Task ListMetafieldsAttachedToCollection([Required] long collection_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsAttachedToCollection" />
    [HttpGet]
    [Route("collections/{collection_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToCollection([Required] long collection_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("collections/{collection_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task
        UpdateMetafieldForCollection([Required] UpdateMetafieldForCollectionRequest request, [Required] long collection_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}