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
    public override Task ListProductVariants([Required] long product_id, string? fields, int? limit, string? page_info, string? presentment_currencies,
        int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/variants.json")]
    public override Task CreateProductVariant([Required] CreateProductVariantRequest request, [Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/variants/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProductVariants([Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("variants/{variant_id:long}.json")]
    public override Task GetProductVariant([Required] long variant_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("variants/{variant_id:long}.json")]
    public override Task UpdateProductVariant([Required] UpdateProductVariantRequest request, [Required] long variant_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}/variants/{variant_id:long}.json")]
    public override Task DeleteProductVariant([Required] long product_id, [Required] long variant_id)
    {
        throw new NotImplementedException();
    }
}