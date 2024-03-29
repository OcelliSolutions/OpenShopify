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
    [HttpGet]
    [Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events.json")]
    [ProducesResponseType(typeof(FulfillmentEventList), StatusCodes.Status200OK)]
    public override Task ListFulfillmentEventsForSpecificFulfillment([Required] long fulfillment_id,
        [Required] long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events.json")]
    [ProducesResponseType(typeof(FulfillmentEventItem), StatusCodes.Status201Created)]
    public override Task CreateFulfillmentEvent([Required] CreateFulfillmentEventRequest request,
        [Required] long fulfillment_id, [Required] long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events/{event_id:long}.json")]
    [ProducesResponseType(typeof(FulfillmentEventItem), StatusCodes.Status200OK)]
    public override Task GetFulfillmentEvent([Required] long event_id, [Required] long fulfillment_id,
        [Required] long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("orders/{order_id:long}/fulfillments/{fulfillment_id:long}/events/{event_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteFulfillmentEvent([Required] long event_id, [Required] long fulfillment_id,
        [Required] long order_id) => throw new NotImplementedException();
}