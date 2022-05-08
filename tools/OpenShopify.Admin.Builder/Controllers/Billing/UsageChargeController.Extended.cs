using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class UsageChargeController : UsageChargeControllerBase
{
    public override Task CreateUsageCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfUsageCharges(string recurring_application_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCharge(string recurring_application_charge_id, string usage_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }
}