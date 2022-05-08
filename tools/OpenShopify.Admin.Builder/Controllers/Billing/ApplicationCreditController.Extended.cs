using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationCreditController : ApplicationCreditControllerBase
{
    public override Task CreateApplicationCredit()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveAllApplicationCredits(string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleApplicationCredit(string application_credit_id, string? fields = null)
    {
        throw new NotImplementedException();
    }
}