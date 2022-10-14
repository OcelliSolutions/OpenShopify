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
    [Route("product_images/{product_image_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMetafieldsAttachedToProductImage(long? product_image_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("product_images/{product_image_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafieldForProductImage([Required] CreateMetafieldForProductImageRequest request, [Required] long product_image_id) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.DeleteMetafield" />
    [HttpDelete]
    [Route("product_images/{product_image_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteMetafieldForProductImage([Required] long product_image_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("product_images/{product_image_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToProductImage([Required] long metafield_id, [Required] long product_image_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("product_images/{product_image_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task ListMetafieldsAttachedToProductImage([Required] long product_image_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsAttachedToProductImage" />
    [HttpGet]
    [Route("product_images/{product_image_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToProductImage([Required] long product_image_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("product_images/{product_image_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task
        UpdateMetafieldForProductImage([Required] UpdateMetafieldForProductImageRequest request, [Required] long product_image_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}