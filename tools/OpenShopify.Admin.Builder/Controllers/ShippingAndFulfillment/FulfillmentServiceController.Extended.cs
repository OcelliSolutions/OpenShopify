using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentServiceController : IFulfillmentServiceController
{
    /// <inheritdoc />
    [IgnoreApi]
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_services.invalid")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public Task ReceiveListOfAllFulfillmentServicesAsync(string? scope = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IFulfillmentServiceController.ReceiveListOfAllFulfillmentServicesAsync" />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public Task ReceiveListOfAllFulfillmentServicesAsync(FulfillmentServiceScope? scope = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi]
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_services.invalid")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status201Created)]
    public virtual Task CreateNewFulfillmentServiceAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IFulfillmentServiceController.CreateNewFulfillmentServiceAsync" />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_services.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status201Created)]
    public Task CreateNewFulfillmentServiceAsync([Required] FulfillmentServiceItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_services/{fulfillment_service_id}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public Task ReceiveSingleFulfillmentServiceAsync([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi]
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("fulfillment_services/{fulfillment_service_id}.invalid")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public Task ModifyExistingFulfillmentServiceAsync(long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IFulfillmentServiceController.ModifyExistingFulfillmentServiceAsync" />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("fulfillment_services/{fulfillment_service_id}.json")]
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public Task ModifyExistingFulfillmentServiceAsync([Required] long fulfillment_service_id, [Required] FulfillmentServiceItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("fulfillment_services/{fulfillment_service_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task RemoveExistingFulfillmentServiceAsync([Required] long fulfillment_service_id)
    {
        throw new NotImplementedException();
    }
}

public class FulfillmentServiceItem
{
    [JsonPropertyName("fulfillment_service")]
    public FulfillmentService? FulfillmentService { get; set; }
}

public class FulfillmentServiceList
{
    [JsonPropertyName("fulfillment_services")]
    public IEnumerable<FulfillmentService>? FulfillmentServices { get; set; }
}
