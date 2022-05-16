using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryLevelController : IInventoryLevelController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("inventory_levels.json")]
    public Task RetrieveListOfInventoryLevelsAsync(string? inventory_item_ids, string limit, string? location_ids,
        string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("inventory_levels.json")]
    public Task DeleteInventoryLevelFromLocationAsync(string inventory_item_id, string location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("inventory_levels/adjust.json")]
    public Task AdjustTheInventoryLevelOfInventoryItemAtLocationAsync(string available_adjustment, string inventory_item_id,
        string location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("inventory_levels/connect.json")]
    public Task ConnectInventoryItemToLocationAsync(string inventory_item_id, string location_id, string relocate_if_necessary)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("inventory_levels/set.json")]
    public Task SetTheInventoryLevelForInventoryItemAtLocationAsync(string available, string inventory_item_id, string location_id,
        string disconnect_if_necessary)
    {
        throw new NotImplementedException();
    }
}