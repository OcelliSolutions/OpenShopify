using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentEventController : FulfillmentEventControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events.json")]
    public override Task ListFulfillmentEventsForSpecificFulfillment([Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events.json")]
    public override Task CreateFulfillmentEvent([Required] CreateFulfillmentEventRequest request, [Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events/{event_id:long}.json")]
    public override Task GetSpecificFulfillmentEvent([Required] long event_id, [Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events/{event_id:long}.json")]
    public override Task DeleteFulfillmentEvent([Required] long event_id, [Required] long fulfillment_id, [Required] long order_id)
    {
        throw new NotImplementedException();
    }
}