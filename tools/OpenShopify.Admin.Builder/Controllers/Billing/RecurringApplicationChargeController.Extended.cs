using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class RecurringApplicationChargeController : RecurringApplicationChargeControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task CreateRecurringApplicationCharge()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(RecurringApplicationChargeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfRecurringApplicationCharges(string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleCharge(string recurring_application_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task CancelRecurringApplicationCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task UpdateTheCappedAmountOfRecurringApplicationCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }
}

public class RecurringApplicationChargeItem
{
    [JsonPropertyName("recurring_application_charge")]
    public RecurringApplicationCharge? RecurringApplicationCharge { get; set; }
}

public class RecurringApplicationChargeList
{
    [JsonPropertyName("recurring_application_charges")]
    public IEnumerable<RecurringApplicationCharge>? RecurringApplicationCharges { get; set; }
}