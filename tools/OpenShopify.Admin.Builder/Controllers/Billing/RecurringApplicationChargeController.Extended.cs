using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class RecurringApplicationChargeController : IRecurringApplicationChargeController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public Task CreateRecurringApplicationChargeAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeList), StatusCodes.Status200OK)]
    public Task RetrieveListOfRecurringApplicationChargesAsync(string? fields, string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public Task RetrieveSingleChargeAsync(string recurring_application_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task CancelRecurringApplicationChargeAsync(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}/customize.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public Task UpdateTheCappedAmountOfRecurringApplicationChargeAsync(string recurring_application_charge_id)
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