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
public class CollectionController : CollectionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("collections/{collection_id:long}.json")]
    [ProducesResponseType(typeof(CollectionItem), StatusCodes.Status200OK)]
    public override Task GetCollection([Required] long collection_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("collections/{collection_id:long}/products.json")]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task ListProductsBelongingToCollection([Required] long collection_id, int? limit = null, string? page_info = null)
    {
        throw new NotImplementedException();
    }
}