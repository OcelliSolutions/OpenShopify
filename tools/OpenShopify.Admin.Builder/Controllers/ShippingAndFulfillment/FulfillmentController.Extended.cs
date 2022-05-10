using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentController : FulfillmentControllerBase
{
    public override Task RetrieveFulfillmentsAssociatedWithOrder([FromRoute] string order_id, string? created_at_max = null,
        string? created_at_min = null, string? fields = null, string? limit = "50", string? since_id = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewFulfillment([FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveFulfillmentsAssociatedWithFulfillmentOrder(string fulfillment_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfFulfillmentsAssociatedWithSpecificOrder([FromRoute] string order_id, string? created_at_max = null,
        string? created_at_min = null, string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleFulfillment([FromRoute] string fulfillment_id, [FromRoute] string order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingFulfillment([FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateFulfillmentForOneOrManyFulfillmentOrders()
    {
        throw new NotImplementedException();
    }

    public override Task UpdateTheTrackingInformationForFulfillment([FromRoute] string fulfillment_id)
    {
        throw new NotImplementedException();
    }

    public override Task CompleteFulfillment([FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task TransitionFulfillmentFromPendingToOpen([FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillmentForSpecificOrderID([FromRoute] string fulfillment_id, [FromRoute] string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillment([FromRoute] string fulfillment_id)
    {
        throw new NotImplementedException();
    }
}