using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Inventory;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Inventory)]
[ApiController]
public class LocationController : LocationControllerBase
{
    public override Task RetrieveListOfLocations()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleLocationByItsID(string location_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfLocations()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfInventoryLevelsForLocation(string location_id)
    {
        throw new NotImplementedException();
    }
}