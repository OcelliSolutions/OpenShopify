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

    public override Task UpdateCarrierService(string carrier_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCarrierService(string carrier_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteCarrierService(string carrier_service_id)
    {
        throw new NotImplementedException();
    }
}