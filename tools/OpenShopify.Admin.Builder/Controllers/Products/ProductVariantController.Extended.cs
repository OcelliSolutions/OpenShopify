using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductVariantController : ProductVariantControllerBase
{
    public override Task RetrieveListOfProductVariants(string product_id, string? fields = null, string? limit = "50",
        string? presentment_currencies = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewProductVariant(string product_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveCountOfAllProductVariants(string product_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleProductVariant(string variant_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingProductVariant(string variant_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingProductVariant(string product_id, string variant_id)
    {
        throw new NotImplementedException();
    }
}