using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentEventController : IFulfillmentEventController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/events.json")]
    public Task RetrieveListOfFulfillmentEventsForSpecificFulfillmentAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/events.json")]
    public Task CreateFulfillmentEventAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/events/{event_id}.json")]
    public Task RetrieveSpecificFulfillmentEventAsync(string event_id, string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/events/{event_id}.json")]
    public Task DeleteFulfillmentEventAsync(string event_id, string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }
}