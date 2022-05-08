using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class SmartCollectionController : SmartCollectionControllerBase
{
    public override Task RetrieveListOfSmartCollections(string? fields = null, string? handle = null, string? ids = null,
        string? limit = "50", string? product_id = null, string? published_at_max = null, string? published_at_min = null,
        string? published_status = "any", string? since_id = null, string? title = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateSmartCollection()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfSmartCollections(string? product_id = null, string? published_at_max = null,
        string? published_at_min = null, string? published_status = "any", string? title = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleSmartCollection(string smart_collection_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingSmartCollection(string smart_collection_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveSmartCollection(string smart_collection_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateTheOrderingTypeOfProductsInSmartCollection(string smart_collection_id, string? products = null,
        string? sort_order = "(current value)")
    {
        throw new NotImplementedException();
    }
}