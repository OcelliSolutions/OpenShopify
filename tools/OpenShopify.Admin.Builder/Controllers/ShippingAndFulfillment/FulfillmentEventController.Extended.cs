using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentEventController : FulfillmentEventControllerBase
{
    public override Task RetrieveListOfFulfillmentEventsForSpecificFulfillment(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateFulfillmentEvent([FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificFulfillmentEvent(string event_id, string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteFulfillmentEvent([FromRoute] string event_id, [FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }
}