using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentServiceController : FulfillmentServiceControllerBase
{
    /// <inheritdoc />
    [IgnoreApi, HttpGet, Route("fulfillment_services.invalid")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public override Task ListFulfillmentServices(string? scope)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="FulfillmentServiceControllerBase.ListFulfillmentServices" />
    [HttpGet, Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public Task ListFulfillmentServices(FulfillmentServiceScope? scope)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(FulfillmentServiceError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateFulfillmentService([Required] CreateFulfillmentServiceRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task GetFulfillmentService([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    /// <inheritdoc cref="FulfillmentServiceControllerBase.UpdateFulfillmentService" />
    [HttpPut, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task UpdateFulfillmentService([Required] UpdateFulfillmentServiceRequest request, [Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteFulfillmentService([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }
}
