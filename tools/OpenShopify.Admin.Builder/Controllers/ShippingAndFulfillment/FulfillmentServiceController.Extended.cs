using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentServiceController : FulfillmentServiceControllerBase
{

    /// <inheritdoc />
    [ProducesResponseType(typeof(FulfillmentServiceList), StatusCodes.Status200OK)]
    public override Task ReceiveListOfAllFulfillmentServices(string? scope = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task CreateNewFulfillmentService()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task ReceiveSingleFulfillmentService([FromRoute] string fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(FulfillmentServiceItem), StatusCodes.Status200OK)]
    public override Task ModifyExistingFulfillmentService([FromRoute] string fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveExistingFulfillmentService([FromRoute] string fulfillment_service_id)
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
