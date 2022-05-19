using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentServiceController : FulfillmentServiceControllerBase
{
    /// <inheritdoc />
    [IgnoreApi, HttpGet, Route("fulfillment_services.invalid")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public override Task ReceiveListOfAllFulfillmentServices(string? scope = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="FulfillmentServiceControllerBase.ReceiveListOfAllFulfillmentServices" />
    [HttpGet, Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public Task ReceiveListOfAllFulfillmentServices(FulfillmentServiceScope? scope = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status201Created)]
    public override Task CreateNewFulfillmentService([Required] FulfillmentServiceItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task ReceiveSingleFulfillmentService([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }
    /// <inheritdoc />
    /// <inheritdoc cref="FulfillmentServiceControllerBase.ModifyExistingFulfillmentService" />
    [HttpPut, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task ModifyExistingFulfillmentService(FulfillmentServiceItem request, long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("fulfillment_services/{fulfillment_service_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveExistingFulfillmentService([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }
}
