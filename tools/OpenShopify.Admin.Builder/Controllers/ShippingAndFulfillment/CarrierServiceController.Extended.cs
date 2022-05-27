using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(typeof(CarrierServiceItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CarrierServiceError), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CarrierServiceGeneralError), StatusCodes.Status400BadRequest)]
    public override Task CreateCarrierService([Required] CreateCarrierServiceRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("carrier_services.json")]
    [ProducesResponseType(typeof(CarrierServiceList), StatusCodes.Status200OK)]
    public override Task ListCarrierServices()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("carrier_services/{carrier_service_id:long}.json")]
    [ProducesResponseType(typeof(CarrierServiceItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CarrierServiceGeneralError), StatusCodes.Status400BadRequest)]
    public override Task UpdateCarrierService([Required] UpdateCarrierServiceRequest request, [Required] long carrier_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("carrier_services/{carrier_service_id:long}.json")]
    [ProducesResponseType(typeof(CarrierServiceItem), StatusCodes.Status200OK)]
    public override Task GetCarrierService([Required] long carrier_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("carrier_services/{carrier_service_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCarrierService([Required] long carrier_service_id)
    {
        throw new NotImplementedException();
    }
}