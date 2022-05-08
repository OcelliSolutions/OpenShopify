using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CollectController : CollectControllerBase
{
    public override Task AddProductToCustomCollection()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfCollects(string? fields = null, string? limit = "50", string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveProductFromCollection(string collect_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificCollectByItsID(string collect_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfCollects()
    {
        throw new NotImplementedException();
    }
}