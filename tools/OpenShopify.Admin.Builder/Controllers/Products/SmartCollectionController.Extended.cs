using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class SmartCollectionController : SmartCollectionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("smart_collections.json")]
    [ProducesResponseType(typeof(SmartCollectionList), StatusCodes.Status200OK)]
    public override Task ListSmartCollections(string? fields = null, string? handle = null, string? ids = null, int? limit = null, string? page_info = null, long? product_id = null,
        DateTimeOffset? published_at_max = null, DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null, string? title = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("smart_collections.json")]
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status201Created)]
    public override Task CreateSmartCollection([Required] CreateSmartCollectionRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("smart_collections/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountSmartCollections(long? product_id = null, DateTimeOffset? published_at_max = null, DateTimeOffset? published_at_min = null,
        string? published_status = null, string? title = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status200OK)]
    public override Task GetSmartCollection([Required] long smart_collection_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("smart_collections/{smart_collection_id:long}.json")]
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status200OK)]
    public override Task UpdateSmartCollection([Required] UpdateSmartCollectionRequest request, [Required] long smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("smart_collections/{smart_collection_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteSmartCollection([Required] long smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("smart_collections/{smart_collection_id:long}/order.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //TODO: wrong request type
    public override Task UpdateOrderingTypeOfProductsInSmartCollection([Required] UpdateSmartCollectionRequest request, [Required] long smart_collection_id,
        string? products, string? sort_order = "(current value)")
    {
        throw new NotImplementedException();
    }
}
