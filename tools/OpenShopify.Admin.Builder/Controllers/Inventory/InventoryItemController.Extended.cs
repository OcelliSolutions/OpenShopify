using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryItemController : InventoryItemControllerBase
{
    public override Task RetrieveListOfInventoryItems(string ids, string? limit = "50")
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleInventoryItemByID(string inventory_item_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingInventoryItem(string inventory_item_id)
    {
        throw new NotImplementedException();
    }
}