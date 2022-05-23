using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductVariantController : ProductVariantControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/variants.json")]
    [ProducesResponseType(typeof(ProductVariantList), StatusCodes.Status200OK)]
    public override Task ListProductVariants([Required] long product_id, string? fields = null, int? limit = null, string? page_info = null, string? presentment_currencies = null,
        long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/variants.json")]
    [ProducesResponseType(typeof(ProductVariantItem), StatusCodes.Status201Created)]
    public override Task CreateProductVariant([Required] CreateProductVariantRequest request, [Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/variants/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProductVariants(long? product_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("variants/{variant_id:long}.json")]
    [ProducesResponseType(typeof(ProductVariantItem), StatusCodes.Status200OK)]
    public override Task GetProductVariant([Required] long variant_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("variants/{variant_id:long}.json")]
    [ProducesResponseType(typeof(ProductVariantItem), StatusCodes.Status200OK)]
    public override Task UpdateProductVariant([Required] UpdateProductVariantRequest request, [Required] long variant_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}/variants/{variant_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProductVariant([Required] long product_id, [Required] long variant_id)
    {
        throw new NotImplementedException();
    }
}