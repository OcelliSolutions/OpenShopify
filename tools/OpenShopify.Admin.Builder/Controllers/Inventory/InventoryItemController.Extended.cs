using System.ComponentModel.DataAnnotations;
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
    [HttpGet]
    [Route("inventory_items.json")]
    [ProducesResponseType(typeof(InventoryItemList), StatusCodes.Status200OK)]
    public override Task ListInventoryItems([Required, FromQuery] IEnumerable<long>? ids = null, int? limit = null,
        string? page_info = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("inventory_items/{inventory_item_id:long}.json")]
    [ProducesResponseType(typeof(InventoryItemItem), StatusCodes.Status200OK)]
    public override Task GetInventoryItem([Required] long inventory_item_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("inventory_items/{inventory_item_id:long}.json")]
    [ProducesResponseType(typeof(InventoryItemItem), StatusCodes.Status200OK)]
    public override Task UpdateInventoryItem([Required] UpdateInventoryItemRequest request,
        [Required] long inventory_item_id) => throw new NotImplementedException();
}