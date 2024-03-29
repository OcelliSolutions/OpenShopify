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
    [HttpPost]
    [Route("checkouts.json")]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status202Accepted)]
    public override Task CreateCheckout([Required] CreateCheckoutRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpPost]
    [Route("checkouts/{token}/complete.invalid")]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status202Accepted)]
    public override Task CompleteCheckout([Required] CompleteCheckoutRequest request, string? token) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="CheckoutControllerBase.CompleteCheckout" />
    [HttpPost]
    [Route("checkouts/{token}/complete.json")]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status202Accepted)]
    public Task CompleteCheckout([Required] string token) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts/{token}.json")]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status200OK)]
    public override Task GetCheckout(string token) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("checkouts/{token}.json")]
    [ProducesResponseType(typeof(CheckoutItem), StatusCodes.Status200OK)]
    public override Task UpdateCheckout([Required] UpdateCheckoutRequest request, string token) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts/{token}/shipping_rates.json")]
    [ProducesResponseType(typeof(ShippingRateList), StatusCodes.Status200OK)]
    public override Task ListShippingRates(string token) => throw new NotImplementedException();
}