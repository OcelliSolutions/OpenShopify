using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class CheckoutController : CheckoutControllerBase
{
    public override Task CreateCheckout()
    {
        throw new NotImplementedException();
    }

    public override Task CompleteCheckout(string token)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCheckout(string token)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingCheckout(string token)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfShippingRates(string token)
    {
        throw new NotImplementedException();
    }
}