using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductController : ProductControllerBase
{
    public override Task RetrieveListOfProducts(string? collection_id = null, string? created_at_max = null, string? created_at_min = null,
        string? fields = null, string? handle = null, string? ids = null, string? limit = "50",
        string? presentment_currencies = null, string? product_type = null, string? published_at_max = null,
        string? published_at_min = null, string? published_status = "any", string? since_id = null, string? status = "any",
        string? title = null, string? updated_at_max = null, string? updated_at_min = null, string? vendor = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewProduct()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfProducts(string? collection_id = null, string? created_at_max = null, string? created_at_min = null,
        string? product_type = null, string? published_at_max = null, string? published_at_min = null,
        string? published_status = "any", string? updated_at_max = null, string? updated_at_min = null,
        string? vendor = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleProduct(string product_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateProduct(string product_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteProduct(string product_id)
    {
        throw new NotImplementedException();
    }
}