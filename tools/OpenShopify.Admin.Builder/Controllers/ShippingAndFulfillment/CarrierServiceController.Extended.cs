using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class CarrierServiceController : CarrierServiceControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("carrier_services.json")]
    public override Task CreateCarrierService(CreateCarrierServiceRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("carrier_services.json")]
    public override Task ListCarrierServices()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("carrier_services/{carrier_service_id:long}.json")]
    public override Task UpdateCarrierService(UpdateCarrierServiceRequest request, long carrier_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("carrier_services/{carrier_service_id:long}.json")]
    public override Task GetCarrierService(long carrier_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("carrier_services/{carrier_service_id:long}.json")]
    public override Task DeleteCarrierService(long carrier_service_id)
    {
        throw new NotImplementedException();
    }
}