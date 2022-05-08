using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentController : FulfillmentControllerBase
{
    public override Task RetrieveFulfillmentsAssociatedWithOrder(string order_id, string? created_at_max = null,
        string? created_at_min = null, string? fields = null, string? limit = "50", string? since_id = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewFulfillment(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveFulfillmentsAssociatedWithFulfillmentOrder(string fulfillment_order_idPath,
        string? fulfillment_order_idQuery = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfFulfillmentsAssociatedWithSpecificOrder(string order_id, string? created_at_max = null,
        string? created_at_min = null, string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleFulfillment(string fulfillment_id, string order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingFulfillment(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateFulfillmentForOneOrManyFulfillmentOrders()
    {
        throw new NotImplementedException();
    }

    public override Task UpdateTheTrackingInformationForFulfillment(string fulfillment_id)
    {
        throw new NotImplementedException();
    }

    public override Task CompleteFulfillment(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task TransitionFulfillmentFromPendingToOpen(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillmentForSpecificOrderID(string fulfillment_id, string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelFulfillment(string fulfillment_id)
    {
        throw new NotImplementedException();
    }
}