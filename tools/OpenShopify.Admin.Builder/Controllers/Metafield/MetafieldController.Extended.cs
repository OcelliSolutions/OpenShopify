using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Metafield)]
[ApiController]
public class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public override Task ListMetafieldsFromResourcesEndpoint(DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null,
        string? fields = null, string? key = null, int? limit = null, string? page_info = null,
        string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null, string? value_type = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(MetafieldError), StatusCodes.Status400BadRequest)]
    public override Task CreateMetafield([Required] CreateMetafieldRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountResourcesMetafields() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafield([Required] long metafield_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task UpdateMetafield([Required] UpdateMetafieldRequest request, [Required] long metafield_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafield([Required] long metafield_id) => throw new NotImplementedException();
}