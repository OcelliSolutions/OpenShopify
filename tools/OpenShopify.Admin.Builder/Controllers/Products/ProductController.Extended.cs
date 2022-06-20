using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductController : ProductControllerBase
{
    /// <inheritdoc />
    [IgnoreApi, HttpGet, Route("products.invalid")]
    [ProducesResponseHeader("Link", StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task ListProducts(long collection_id, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? handle = null, [FromQuery] IEnumerable<long>? ids = null, int? limit = null, string? page_info = null,
        string? presentment_currencies = null, string? product_type = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null,
        string? status = null, string? title = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null, string? vendor = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="ProductControllerBase.ListProducts" />
    [HttpGet, Route("products.json")]
    [ProducesResponseHeader("Link", StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public Task ListProducts(long? collection_id, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? handle = null, [FromQuery] IEnumerable<long>? ids = null, int? limit = null, string? page_info = null,
        string? presentment_currencies = null, string? product_type = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null,
        string? status = null, string? title = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null, string? vendor = null)
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    [HttpPost, Route("products.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProductError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateProduct([Required] CreateProductRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProducts(long? collection_id = null, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? product_type = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null, string? vendor = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status200OK)]
    public override Task GetProduct([Required] long product_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("products/{product_id:long}.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateProduct([Required] UpdateProductRequest request, [Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProduct([Required] long product_id)
    {
        throw new NotImplementedException();
    }
}
