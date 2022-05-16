using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductVariantController : IProductVariantController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/variants.json")]
    public Task RetrieveListOfProductVariantsAsync(string product_id, string? fields, string limit, string? presentment_currencies,
        string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/variants.json")]
    public Task CreateNewProductVariantAsync(string product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/variants/count.json")]
    public Task ReceiveCountOfAllProductVariantsAsync(string product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("variants/{variant_id}.json")]
    public Task ReceiveSingleProductVariantAsync(string variant_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("variants/{variant_id}.json")]
    public Task ModifyExistingProductVariantAsync(string variant_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/variants/{variant_id}.json")]
    public Task RemoveExistingProductVariantAsync(string product_id, string variant_id)
    {
        throw new NotImplementedException();
    }
}