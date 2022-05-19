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
    [HttpGet, Route("products.json")]
    [ProducesResponseHeader("Link", StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfProducts(long? collection_id, DateTime? created_at_max, DateTime? created_at_min, string? fields,
        string? handle, string? ids, int? limit, string? page_info, string? presentment_currencies, string? product_type,
        DateTime? published_at_max, DateTime? published_at_min, string published_status, int? since_id, string status,
        string? title, DateTime? updated_at_max, DateTime? updated_at_min, string? vendor)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status201Created)]
    public override Task CreateNewProduct([Required] ProductItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/count.json")]
    [ProducesResponseType(typeof(ProductCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfProducts(long? collection_id, DateTime? created_at_max, DateTime? created_at_min,
        string? product_type, DateTime? published_at_max, DateTime? published_at_min, string published_status,
        DateTime? updated_at_max, DateTime? updated_at_min, string? vendor)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleProduct([Required] long product_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPut, Route("products/{product_id:long}.invalid")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status200OK)]
    public override Task UpdateProduct(ProductItem request, long productId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="ProductControllerBase.UpdateProduct" />
    [HttpPut, Route("products/{product_id:long}.json")]
    [ProducesResponseType(typeof(ProductItem), StatusCodes.Status200OK)]
    public Task UpdateProduct([Required] long product_id, [Required] ProductItem request)
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
