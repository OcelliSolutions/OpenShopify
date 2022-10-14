using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Metafield)]
[ApiController]
public partial class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMetafieldsAttachedToShopResource() => throw new NotImplementedException();

    [IgnoreApi]
    [HttpGet]
    [Route("pages/{page_id}/metafields/count.invalid")]
    public override Task CountResourcesMetafields(long? page_id = null) => throw new NotImplementedException();

    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafield(CreateMetafieldRequest request) => throw new NotImplementedException();

    [IgnoreApi]
    [HttpDelete]
    [Route("product_images/{product_image_id}/metafields/{metafield_id}.invalid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafield(long metafield_id, long product_image_id) =>
        throw new NotImplementedException();

    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldForShopResource(long metafield_id) => throw new NotImplementedException();

    [IgnoreApi]
    [HttpGet]
    [Route("variants/{variant_id}/metafields/{metafield_id}.invalid")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafield(long metafield_id, long variant_id, string? fields = null) =>
        throw new NotImplementedException();
    
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToShopResource(long metafield_id, string? fields = null) =>
        throw new NotImplementedException();

    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public override Task ListMetafieldsByUsingQueryParameters(string? metafieldowner_id = null,
        string? metafieldowner_resource = null) => throw new NotImplementedException();

    [IgnoreApi]
    [HttpGet]
    [Route("blogs/{blog_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public override Task ListMetafieldsFromResourcesEndpoint(long blog_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task UpdateMetafield([Required] UpdateMetafieldRequest request, [Required] long metafield_id) =>
        throw new NotImplementedException();
}