using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductImageController : ProductImageControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/images.json")]
    [ProducesResponseType(typeof(ProductImageList), StatusCodes.Status200OK)]
    public override Task ListProductImages([Required] long product_id, string? fields = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/images.json")]
    [ProducesResponseType(typeof(ProductImageItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductImageError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateProductImage([Required] CreateProductImageRequest request, [Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/images/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProductImages(long? product_id = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/images/{image_id:long}.json")]
    [ProducesResponseType(typeof(ProductImageItem), StatusCodes.Status200OK)]
    public override Task GetProductImage([Required] long image_id, [Required] long product_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("products/{product_id:long}/images/{image_id:long}.json")]
    [ProducesResponseType(typeof(ProductImageItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductImageError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateProductImage([Required] UpdateProductImageRequest request, [Required] long image_id, [Required] long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}/images/{image_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProductImage([Required] long image_id, [Required] long product_id)
    {
        throw new NotImplementedException();
    }
}
