using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CustomCollectionController : CustomCollectionControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("custom_collections.json")]
    [ProducesResponseType(typeof(CustomCollectionList), StatusCodes.Status200OK)]
    public override Task ListCustomCollections(string? fields = null, string? handle = null,
        [FromQuery] IEnumerable<long>? ids = null, int? limit = null,
        string? page_info = null, long? product_id = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null,
        string? title = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("custom_collections.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status201Created)]
    public override Task CreateCustomCollection([Required] CreateCustomCollectionRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("custom_collections/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCustomCollections(long? product_id = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, string? title = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status200OK)]
    public override Task GetCustomCollection([Required] long custom_collection_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomCollection([Required] UpdateCustomCollectionRequest request,
        [Required] long custom_collection_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCustomCollection([Required] long custom_collection_id) =>
        throw new NotImplementedException();
}