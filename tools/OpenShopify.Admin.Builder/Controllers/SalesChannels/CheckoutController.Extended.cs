using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class CheckoutController : CheckoutControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("checkouts.json")]
    public override Task CreateCheckout(CheckoutItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("checkouts/{token:long}/complete.json")]
    public override Task CompleteCheckout(string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}.json")]
    public override Task RetrieveCheckout(string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("checkouts/{token:long}.json")]
    public override Task ModifyExistingCheckout(CheckoutItem request, string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}/shipping_rates.json")]
    public override Task RetrieveListOfShippingRates(string token)
    {
        throw new NotImplementedException();
    }
}