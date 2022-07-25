using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class LocationController : LocationControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("locations.json")]
    [ProducesResponseType(typeof(LocationList), StatusCodes.Status200OK)]
    public override Task ListLocations() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("locations/{location_id:long}.json")]
    [ProducesResponseType(typeof(LocationItem), StatusCodes.Status200OK)]
    public override Task GetLocation([Required] long location_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("locations/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountLocations() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("locations/{location_id:long}/inventory_levels.json")]
    [ProducesResponseType(typeof(LocationList), StatusCodes.Status200OK)]
    public override Task ListInventoryLevelsForLocation([Required] long location_id) =>
        throw new NotImplementedException();
}