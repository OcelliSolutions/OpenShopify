using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class PaymentController : PaymentControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("checkouts/{token}/payments.json")]
    [ProducesResponseType(typeof(PaymentItem), StatusCodes.Status201Created)]
    public override Task CreatePayment([Required] CreatePaymentRequest request, string token) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts/{token}/payments.json")]
    [ProducesResponseType(typeof(PaymentList), StatusCodes.Status200OK)]
    public override Task ListPaymentsOnParticularCheckout(string token) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts/{token}/payments/{payment_id:long}.json")]
    [ProducesResponseType(typeof(PaymentItem), StatusCodes.Status200OK)]
    public override Task GetPayment([Required] long payment_id, string token) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("checkouts/{token}/payments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountNumberOfPaymentsAttemptedOnCheckout(string token) => throw new NotImplementedException();
}