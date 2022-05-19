using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryItemController : InventoryItemControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("inventory_items.json")]
    [ProducesResponseType(typeof(InventoryItemList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfInventoryItems(string ids, int? limit, string? page_info)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("inventory_items/{inventory_item_id:long}.json")]
    [ProducesResponseType(typeof(InventoryItemItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleInventoryItemByID(long inventory_item_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("inventory_items/{inventory_item_id:long}.json")]
    [ProducesResponseType(typeof(InventoryItemItem), StatusCodes.Status200OK)]
    public override Task UpdateExistingInventoryItem(UpdateInventoryItemRequest request, long inventory_item_id)
    {
        throw new NotImplementedException();
    }
}