using System.ComponentModel.DataAnnotations;
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
    public override Task CreateCheckout([Required] CreateCheckoutRequest request)
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
    public override Task GetCheckout(string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("checkouts/{token:long}.json")]
    public override Task UpdateCheckout([Required] UpdateCheckoutRequest request, string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}/shipping_rates.json")]
    public override Task ListShippingRates(string token)
    {
        throw new NotImplementedException();
    }
}