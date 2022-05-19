using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class SmartCollectionController : SmartCollectionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("smart_collections.json")]
    [ProducesResponseType(typeof(SmartCollectionList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfSmartCollections(string? fields, string? handle, string? ids, int? limit, string? page_info, long? product_id,
        DateTime? published_at_max, DateTime? published_at_min, string published_status, int? since_id, string? title,
        DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("smart_collections.json")]
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status201Created)]
    public override Task CreateSmartCollection(SmartCollectionItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("smart_collections/count.json")]
    [ProducesResponseType(typeof(SmartCollectionCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfSmartCollections(long? product_id, DateTime? published_at_max, DateTime? published_at_min,
        string published_status, string? title, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleSmartCollection(long smart_collection_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("smart_collections/{smart_collection_id:long}.json")]
    [ProducesResponseType(typeof(SmartCollectionItem), StatusCodes.Status200OK)]
    public override Task UpdateExistingSmartCollection(SmartCollectionItem request, long smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("smart_collections/{smart_collection_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveSmartCollection(long smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("smart_collections/{smart_collection_id:long}/order.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task UpdateOrderingTypeOfProductsInSmartCollection(SmartCollectionItem request, long smart_collection_id,
        string? products, string? sort_order = "(current value)")
    {
        throw new NotImplementedException();
    }
}
