using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class InventoryLevelController : InventoryLevelControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("inventory_levels.json")]
    [ProducesResponseType(typeof(InventoryLevelList), StatusCodes.Status200OK)]
    public override Task ListInventoryLevels(long? inventory_item_ids, int? limit, string? page_info, long? location_ids,
        DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("inventory_levels.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteInventoryLevelFromLocation([Required] long inventory_item_id, [Required] long location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("inventory_levels/adjust.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status200OK)]
    public override Task AdjustInventoryLevelOfInventoryItemAtLocation(string available_adjustment, [Required] long inventory_item_id,
        [Required] long location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("inventory_levels/connect.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status201Created)]
    public override Task ConnectInventoryItemToLocation([Required] long inventory_item_id, [Required] long location_id, bool? relocate_if_necessary)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("inventory_levels/set.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status200OK)]
    public override Task SetInventoryLevelForInventoryItemAtLocation(string available, [Required] long inventory_item_id, [Required] long location_id,
        bool? disconnect_if_necessary)
    {
        throw new NotImplementedException();
    }
}