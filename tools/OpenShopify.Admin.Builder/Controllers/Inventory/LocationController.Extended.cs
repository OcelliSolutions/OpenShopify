using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class LocationController : LocationControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("locations.json")]
    [ProducesResponseType(typeof(LocationList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfLocations()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("locations/{location_id:long}.json")]
    [ProducesResponseType(typeof(LocationItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleLocationByItsID(long location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("locations/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfLocations()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("locations/{location_id:long}/inventory_levels.json")]
    [ProducesResponseType(typeof(LocationList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfInventoryLevelsForLocation(long location_id)
    {
        throw new NotImplementedException();
    }
}
