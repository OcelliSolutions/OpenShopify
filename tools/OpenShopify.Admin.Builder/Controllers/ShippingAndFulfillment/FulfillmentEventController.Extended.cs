using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentEventController : FulfillmentEventControllerBase
{
    public override Task RetrieveListOfFulfillmentEventsForSpecificFulfillment(string fulfillment_idPath, string order_idPath,
        string? fulfillment_idQuery = null, string? order_idQuery = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateFulfillmentEvent(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificFulfillmentEvent(string event_idPath, string fulfillment_id, string order_id,
        string? event_idQuery = null)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteFulfillmentEvent(string event_id, string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }
}