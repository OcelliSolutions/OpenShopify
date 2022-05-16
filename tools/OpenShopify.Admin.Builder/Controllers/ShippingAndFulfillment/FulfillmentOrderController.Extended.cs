using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentOrderController : IFulfillmentOrderController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillment_orders.json")]
    public Task RetrieveListOfFulfillmentOrdersForSpecificOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}.json")]
    public Task RetrieveSpecificFulfillmentOrderAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/cancel.json")]
    public Task CancelFulfillmentOrderAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/close.json")]
    public Task MarkFulfillmentOrderAsIncompleteAsync(string fulfillment_order_id, string? message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/move.json")]
    public Task MoveFulfillmentOrderToNewLocationAsync(string fulfillment_order_id, string? new_location_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/open.json")]
    public Task MarkTheFulfillmentOrderAsOpenAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/reschedule.json")]
    public Task RescheduleTheFulfillAtTimeOfScheduledFulfillmentOrderAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/hold.json")]
    public Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusOPENAsync(string fulfillment_order_id, string? notify_merchant,
        string? reason, string? reason_notes)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/release_hold.json")]
    public Task ReleaseTheFulfillmentHoldOnFulfillmentOrderAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}