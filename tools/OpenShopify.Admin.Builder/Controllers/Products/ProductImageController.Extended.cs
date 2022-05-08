using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class ProductImageController : ProductImageControllerBase
{
    public override Task ReceiveListOfAllProductImages(string product_id, string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewProductImage(string product_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveCountOfAllProductImages(string product_id, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleProductImage(string image_id, string product_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingProductImage(string image_id, string product_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingProductImage(string image_id, string product_id)
    {
        throw new NotImplementedException();
    }
}