using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Metafield)]
[ApiController]
public class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public override Task ListMetafieldsFromResourcesEndpoint(DateTime? created_at_max, DateTime? created_at_min,
        string? fields, string? key, int? limit, string? page_info, string? @namespace, int? since_id, string? type,
        DateTime? updated_at_max, DateTime? updated_at_min, string? value_type)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafield(CreateMetafieldRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfResourcesMetafields()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetSpecificMetafield(long metafield_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task UpdateMetafield(UpdateMetafieldRequest request, long metafield_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("metafields/{metafield_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldByItsID(long metafield_id)
    {
        throw new NotImplementedException();
    }
}