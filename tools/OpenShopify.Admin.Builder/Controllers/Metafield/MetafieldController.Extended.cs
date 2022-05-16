using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Metafield)]
[ApiController]
public class MetafieldController : IMetafieldController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
    public Task RetrieveListOfMetafieldsFromTheResourcesEndpointAsync(string? created_at_max, string? created_at_min,
        string? fields, string? key, string limit, string? @namespace, string? since_id, string? type,
        string? updated_at_max, string? updated_at_min, string? value_type)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
    public Task CreateMetafieldAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/count.json")]
    public Task RetrieveCountOfResourcesMetafieldsAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
    public Task RetrieveSpecificMetafieldAsync(string metafield_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
    public Task UpdateMetafieldAsync(string metafield_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
    public Task DeleteMetafieldByItsIDAsync(string metafield_id)
    {
        throw new NotImplementedException();
    }
}