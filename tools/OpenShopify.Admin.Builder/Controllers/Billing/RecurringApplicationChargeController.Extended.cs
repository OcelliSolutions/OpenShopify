using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class RecurringApplicationChargeController : RecurringApplicationChargeControllerBase
{
    public override Task CreateRecurringApplicationCharge()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfRecurringApplicationCharges(string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCharge(string recurring_application_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task CancelRecurringApplicationCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateTheCappedAmountOfRecurringApplicationCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }
}