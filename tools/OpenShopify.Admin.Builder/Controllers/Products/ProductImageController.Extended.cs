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
    public override Task ReceiveListOfAllProductImages(long product_id, string? fields, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/images.json")]
    public override Task CreateNewProductImage(ProductImageItem request, long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/images/count.json")]
    [ProducesResponseType(typeof(ImageCount), StatusCodes.Status200OK)]
    public override Task ReceiveCountOfAllProductImages(long product_id, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/images/{image_id:long}.json")]
    public override Task ReceiveSingleProductImage(long image_id, long product_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("products/{product_id:long}/images/{image_id:long}.json")]
    public override Task ModifyExistingProductImage(ProductImageItem request, long image_id, long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}/images/{image_id:long}.json")]
    public override Task RemoveExistingProductImage(long image_id, long product_id)
    {
        throw new NotImplementedException();
    }
}
