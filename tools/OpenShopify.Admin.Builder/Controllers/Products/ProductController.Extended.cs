using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductController : IProductController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products.json")]
    public Task RetrieveListOfProductsAsync(string? collection_id, string? created_at_max, string? created_at_min, string? fields,
        string? handle, string? ids, string limit, string? presentment_currencies, string? product_type,
        string? published_at_max, string? published_at_min, string published_status, string? since_id, string status,
        string? title, string? updated_at_max, string? updated_at_min, string? vendor)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("products.json")]
    public Task CreateNewProductAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/count.json")]
    public Task RetrieveCountOfProductsAsync(string? collection_id, string? created_at_max, string? created_at_min,
        string? product_type, string? published_at_max, string? published_at_min, string published_status,
        string? updated_at_max, string? updated_at_min, string? vendor)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}.json")]
    public Task RetrieveSingleProductAsync(string product_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("products/{product_id}.json")]
    public Task UpdateProductAsync(string product_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("products/{product_id}.json")]
    public Task DeleteProductAsync(string product_id)
    {
        throw new NotImplementedException();
    }
}