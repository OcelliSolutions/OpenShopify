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
    [IgnoreApi]
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("elb.deposit.shopifycs.com/sessions")]
    public override Task StoreCreditCardInCardVault(string credit_card)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("checkouts/{token:long}/payments.json")]
    public override Task CreateNewPayment(CreatePaymentRequest request, string amount, string request_details, string session_id,
        string token, string unique_token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}/payments.json")]
    public override Task RetrieveListOfPaymentsOnParticularCheckout(string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}/payments/{payment_id:long}.json")]

    public override Task RetrieveSinglePayment(long payment_id, string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("checkouts/{token:long}/payments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountNumberOfPaymentsAttemptedOnCheckout(string token)
    {
        throw new NotImplementedException();
    }
}
