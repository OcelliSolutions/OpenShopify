using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class SmartCollectionController : ISmartCollectionController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections.json")]
    public Task RetrieveListOfSmartCollectionsAsync(string? fields, string? handle, string? ids, string limit, string? product_id,
        string? published_at_max, string? published_at_min, string published_status, string? since_id, string? title,
        string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("smart_collections.json")]
    public Task CreateSmartCollectionAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections/count.json")]
    public Task RetrieveCountOfSmartCollectionsAsync(string? product_id, string? published_at_max, string? published_at_min,
        string published_status, string? title, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
    public Task RetrieveSingleSmartCollectionAsync(string smart_collection_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
    public Task UpdateExistingSmartCollectionAsync(string smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
    public Task RemoveSmartCollectionAsync(string smart_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}/order.json")]
    public Task UpdateTheOrderingTypeOfProductsInSmartCollectionAsync(string smart_collection_id, string? products,
        string sort_order)
    {
        throw new NotImplementedException();
    }
}