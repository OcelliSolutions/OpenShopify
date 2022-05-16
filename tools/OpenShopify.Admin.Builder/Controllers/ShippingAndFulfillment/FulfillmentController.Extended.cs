using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentController : IFulfillmentController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments.json")]
    public Task RetrieveFulfillmentsAssociatedWithOrderAsync(string order_id, string? created_at_max, string? created_at_min,
        string? fields, string limit, string? since_id, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments.json")]
    public Task CreateNewFulfillmentAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/fulfillments.json")]
    public Task RetrieveFulfillmentsAssociatedWithFulfillmentOrderAsync(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/count.json")]
    public Task RetrieveCountOfFulfillmentsAssociatedWithSpecificOrderAsync(string order_id, string? created_at_max,
        string? created_at_min, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}.json")]
    public Task ReceiveSingleFulfillmentAsync(string fulfillment_id, string order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}.json")]
    public Task ModifyExistingFulfillmentAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments.json")]
    public Task CreateFulfillmentForOneOrManyFulfillmentOrdersAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments/{fulfillment_id}/update_tracking.json")]
    public Task UpdateTheTrackingInformationForFulfillmentAsync(string fulfillment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/complete.json")]
    public Task CompleteFulfillmentAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/open.json")]
    public Task TransitionFulfillmentFromPendingToOpenAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}/cancel.json")]
    public Task CancelFulfillmentForSpecificOrderIDAsync(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments/{fulfillment_id}/cancel.json")]
    public Task CancelFulfillmentAsync(string fulfillment_id)
    {
        throw new NotImplementedException();
    }
}