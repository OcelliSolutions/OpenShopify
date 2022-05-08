using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class PaymentController : PaymentControllerBase
{
    public override Task CreateNewPayment(string amount, string request_details, string session_id, string token, string unique_token)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfPaymentsOnParticularCheckout(string token)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSinglePayment(string payment_id, string token)
    {
        throw new NotImplementedException();
    }

    public override Task CountTheNumberOfPaymentsAttemptedOnCheckout(string token)
    {
        throw new NotImplementedException();
    }
}