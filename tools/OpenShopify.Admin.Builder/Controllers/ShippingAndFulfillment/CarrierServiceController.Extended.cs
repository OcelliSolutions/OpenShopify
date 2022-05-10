using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CarrierServiceController : CarrierServiceControllerBase
{
    public override Task CreateCarrierService()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfCarrierServices()
    {
        throw new NotImplementedException();
    }

    public override Task UpdateCarrierService([FromRoute] string carrier_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCarrierService([FromRoute] string carrier_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteCarrierService([FromRoute] string carrier_service_id)
    {
        throw new NotImplementedException();
    }
}