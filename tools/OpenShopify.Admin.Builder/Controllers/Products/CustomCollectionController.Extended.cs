using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CustomCollectionController : ICustomCollectionController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("custom_collections.json")]
    public Task RetrieveListOfCustomCollectionsAsync(string? fields, string? handle, string? ids, string limit, string? product_id,
        string? published_at_max, string? published_at_min, string published_status, string? since_id, string? title,
        string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("custom_collections.json")]
    public Task CreateCustomCollectionAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("custom_collections/count.json")]
    public Task RetrieveCountOfCustomCollectionsAsync(string? product_id, string? published_at_max, string? published_at_min,
        string published_status, string? title, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("custom_collections/{custom_collection_id}.json")]
    public Task RetrieveSingleCustomCollectionAsync(string custom_collection_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("custom_collections/{custom_collection_id}.json")]
    public Task UpdateExistingCustomCollectionAsync(string custom_collection_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("custom_collections/{custom_collection_id}.json")]
    public Task DeleteCustomCollectionAsync(string custom_collection_id)
    {
        throw new NotImplementedException();
    }
}