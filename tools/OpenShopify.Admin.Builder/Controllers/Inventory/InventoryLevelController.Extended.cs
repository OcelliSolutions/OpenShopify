using System.ComponentModel.DataAnnotations;
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
    [HttpGet]
    [Route("inventory_levels.json")]
    [ProducesResponseType(typeof(InventoryLevelList), StatusCodes.Status200OK)]
    public override Task ListInventoryLevels(IEnumerable<long>? inventory_item_ids = null, int? limit = null, string? page_info = null,
        string? location_ids = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("inventory_levels.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteInventoryLevelFromLocation([Required] long inventory_item_id,
        [Required] long location_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("inventory_levels/adjust.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status200OK)]
    public override Task AdjustInventoryLevelOfInventoryItemAtLocation(
        [Required] AdjustInventoryLevelOfInventoryItemAtLocationRequest request) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("inventory_levels/connect.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status201Created)]
    public override Task ConnectInventoryItemToLocation([Required] ConnectInventoryItemToLocationRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("inventory_levels/set.json")]
    [ProducesResponseType(typeof(InventoryLevelItem), StatusCodes.Status200OK)]
    public override Task SetInventoryLevelForInventoryItemAtLocation(
        [Required] SetInventoryLevelForInventoryItemAtLocationRequest request) => throw new NotImplementedException();
}