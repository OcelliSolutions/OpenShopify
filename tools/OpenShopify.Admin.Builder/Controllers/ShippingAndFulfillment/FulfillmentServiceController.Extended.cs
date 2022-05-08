using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class FulfillmentServiceController : FulfillmentServiceControllerBase
{
    public override Task ReceiveListOfAllFulfillmentservices(string? scope = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewFulfillmentservice()
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleFulfillmentservice(string fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingFulfillmentservice(string fulfillment_service_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingFulfillmentservice(string fulfillment_service_id)
    {
        throw new NotImplementedException();
    }
}