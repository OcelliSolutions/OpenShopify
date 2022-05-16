using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class PaymentController : IPaymentController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("checkouts/{token}/payments.json")]
    public Task CreateNewPaymentAsync(string amount, string request_details, string session_id, string token, string unique_token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("checkouts/{token}/payments.json")]
    public Task RetrieveListOfPaymentsOnParticularCheckoutAsync(string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("checkouts/{token}/payments/{payment_id}.json")]

    public Task RetrieveSinglePaymentAsync(string payment_id, string token)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("checkouts/{token}/payments/count.json")]
    public Task CountTheNumberOfPaymentsAttemptedOnCheckoutAsync(string token)
    {
        throw new NotImplementedException();
    }
}