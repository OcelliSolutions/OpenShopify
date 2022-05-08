using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CustomCollectionController : CustomCollectionControllerBase
{
    public override Task RetrieveListOfCustomCollections(string? fields = null, string? handle = null, string? ids = null,
        string? limit = "50", string? product_id = null, string? published_at_max = null, string? published_at_min = null,
        string? published_status = "any", string? since_id = null, string? title = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCustomCollection()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfCustomCollections(string? product_id = null, string? published_at_max = null,
        string? published_at_min = null, string? published_status = "any", string? title = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCustomCollection(string custom_collection_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingCustomCollection(string custom_collection_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteCustomCollection(string custom_collection_id)
    {
        throw new NotImplementedException();
    }
}