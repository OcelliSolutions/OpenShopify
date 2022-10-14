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
    [Route("products/{product_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMetafieldsAttachedToProduct(long? product_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("products/{product_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafieldForProduct([Required] CreateMetafieldForProductRequest request, [Required] long product_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("products/{product_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldForProduct([Required] long product_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("products/{product_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToProduct([Required] long metafield_id, [Required] long product_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("products/{product_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task ListMetafieldsAttachedToProduct([Required] long product_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsAttachedToProduct" />
    [HttpGet]
    [Route("products/{product_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToProduct([Required] long product_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("products/{product_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task
        UpdateMetafieldForProduct([Required] UpdateMetafieldForProductRequest request, [Required] long product_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}