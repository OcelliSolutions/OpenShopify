using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryLevelController : InventoryLevelControllerBase
{
    public override Task RetrieveListOfInventoryLevels(string? inventory_item_ids = null, string? limit = "50", string? location_ids = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task AdjustTheInventoryLevelOfInventoryItemAtLocation(string available_adjustment, string inventory_item_id,
        string location_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteInventoryLevelFromLocation(string inventory_item_id, string location_id)
    {
        throw new NotImplementedException();
    }

    public override Task ConnectInventoryItemToLocation(string inventory_item_id, string location_id,
        string? relocate_if_necessary = "false")
    {
        throw new NotImplementedException();
    }

    public override Task SetTheInventoryLevelForInventoryItemAtLocation(string available, string inventory_item_id, string location_id,
        string? disconnect_if_necessary = "false")
    {
        throw new NotImplementedException();
    }
}