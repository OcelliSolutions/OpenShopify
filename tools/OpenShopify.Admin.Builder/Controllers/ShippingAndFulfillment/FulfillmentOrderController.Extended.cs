using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentOrderController : FulfillmentOrderControllerBase
{
    public override Task RetrieveListOfFulfillmentOrdersForSpecificOrder(string order_idPath, string? order_idQuery = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificFulfillmentOrder(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillmentOrder(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task MarkFulfillmentOrderAsIncomplete(string fulfillment_order_id, string? message = null)
    {
        throw new NotImplementedException();
    }

    public override Task MoveFulfillmentOrderToNewLocation(string fulfillment_order_id, string? new_location_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task MarkTheFulfillmentOrderAsOpen(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RescheduleTheFulfillAtTimeOfScheduledFulfillmentOrder(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusCodeOPENCode(string fulfillment_order_id,
        string? notify_merchant = null, string? reason = null, string? reason_notes = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReleaseTheFulfillmentHoldOnFulfillmentOrder(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }
}