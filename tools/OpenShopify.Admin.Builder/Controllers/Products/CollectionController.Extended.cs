using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CollectionController : CollectionControllerBase
{
    public override Task RetrieveSingleCollection(string collection_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfProductsBelongingToCollection(string collection_id, string? limit = "50")
    {
        throw new NotImplementedException();
    }
}