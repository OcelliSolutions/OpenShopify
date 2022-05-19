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
    public override Task RetrieveListOfProductVariants(long product_id, string? fields, int? limit, string? page_info, string? presentment_currencies,
        int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("products/{product_id:long}/variants.json")]
    public override Task CreateNewProductVariant(CreateProductVariantRequest request, long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("products/{product_id:long}/variants/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task ReceiveCountOfAllProductVariants(long product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("variants/{variant_id:long}.json")]
    public override Task ReceiveSingleProductVariant(long variant_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("variants/{variant_id:long}.json")]
    public override Task ModifyExistingProductVariant(UpdateProductVariantRequest request, long variant_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("products/{product_id:long}/variants/{variant_id:long}.json")]
    public override Task RemoveExistingProductVariant(long product_id, long variant_id)
    {
        throw new NotImplementedException();
    }
}