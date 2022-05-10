using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentOrderController : FulfillmentOrderControllerBase
{
    public override Task RetrieveListOfFulfillmentOrdersForSpecificOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificFulfillmentOrder([FromRoute] string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillmentOrder([FromRoute] string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task MarkFulfillmentOrderAsIncomplete([FromRoute] string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task MoveFulfillmentOrderToNewLocation([FromRoute] string fulfillment_order_id, string? new_location_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task MarkTheFulfillmentOrderAsOpen([FromRoute] string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RescheduleTheFulfillAtTimeOfScheduledFulfillmentOrder([FromRoute] string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusOPEN([FromRoute] string fulfillment_order_id, string? notify_merchant = null,
        string? reason = null, string? reason_notes = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReleaseTheFulfillmentHoldOnFulfillmentOrder([FromRoute] string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}