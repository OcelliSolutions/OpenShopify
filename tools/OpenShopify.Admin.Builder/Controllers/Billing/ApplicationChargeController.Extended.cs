using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationChargeController : ApplicationChargeControllerBase
{
    public override Task CreateApplicationCharge()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfApplicationCharges(string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveApplicationCharge(string application_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }
}