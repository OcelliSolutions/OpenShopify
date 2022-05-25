using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class PaymentController : PaymentControllerBase
{
    ///TODO: different URLs https://shopify.dev/api/admin-rest/2022-04/resources/payment#post-https:-elb.deposit.shopifycs.com-sessions
    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("elb.deposit.shopifycs.com/sessions")]
    public override Task StoreCreditCardInCardVault(string credit_card = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("checkouts/{token}/payments.json")]
    [ProducesResponseType(typeof(PaymentItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(PaymentError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreatePayment(CreatePaymentRequest request, decimal? amount = null, string? request_details = null,
        long? session_id = null, string? token = null, string? unique_token = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token}/payments.json")]
    [ProducesResponseType(typeof(PaymentList), StatusCodes.Status200OK)]
    public override Task ListPaymentsOnParticularCheckout(string? token = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token}/payments/{payment_id:long}.json")]
    [ProducesResponseType(typeof(PaymentItem), StatusCodes.Status200OK)]
    public override Task GetPayment([Required] long payment_id, string? token = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token}/payments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountNumberOfPaymentsAttemptedOnCheckout(string? token = null)
    {
        throw new NotImplementedException();
    }
}
