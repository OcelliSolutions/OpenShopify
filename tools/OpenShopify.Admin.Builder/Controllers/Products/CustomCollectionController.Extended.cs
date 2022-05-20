using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CustomCollectionController : CustomCollectionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("custom_collections.json")]
    [ProducesResponseType(typeof(CustomCollectionList), StatusCodes.Status200OK)]
    public override Task ListCustomCollections(string? fields, string? handle, string? ids, int? limit, string? page_info, long? product_id,
        DateTime? published_at_max, DateTime? published_at_min, string published_status, int? since_id, string? title,
        DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("custom_collections.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status201Created)]
    public override Task CreateCustomCollection([Required] CreateCustomCollectionRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("custom_collections/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCustomCollections(long? product_id, DateTime? published_at_max, DateTime? published_at_min,
        string published_status, string? title, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status200OK)]
    public override Task GetCustomCollection([Required] long custom_collection_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(typeof(CustomCollectionItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomCollection([Required] UpdateCustomCollectionRequest request, [Required] long custom_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("custom_collections/{custom_collection_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCustomCollection([Required] long custom_collection_id)
    {
        throw new NotImplementedException();
    }
}
