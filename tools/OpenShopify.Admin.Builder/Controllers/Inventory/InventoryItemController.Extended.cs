using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryItemController : IInventoryItemController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("inventory_items.json")]
    public Task RetrieveListOfInventoryItemsAsync(string ids, string limit)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("inventory_items/{inventory_item_id}.json")]
    public Task RetrieveSingleInventoryItemByIDAsync(string inventory_item_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("inventory_items/{inventory_item_id}.json")]
    public Task UpdateExistingInventoryItemAsync(string inventory_item_id)
    {
        throw new NotImplementedException();
    }
}