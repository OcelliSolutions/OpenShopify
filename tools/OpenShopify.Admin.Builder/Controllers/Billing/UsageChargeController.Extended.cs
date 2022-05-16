using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class UsageChargeController : IUsageChargeController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}/usage_charges.json")]
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status200OK)]
    public Task CreateUsageChargeAsync(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}/usage_charges.json")]
    [ProducesResponseType(typeof(UsageChargeList), StatusCodes.Status200OK)]
    public Task RetrieveListOfUsageChargesAsync(string recurring_application_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("recurring_application_charges/{recurring_application_charge_id}/usage_charges/{usage_charge_id}.json")]
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status200OK)]
    public Task RetrieveSingleChargeAsync(string recurring_application_charge_id, string usage_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }
}

public class UsageChargeItem
{
    [JsonPropertyName("usage_charge")]
    public UsageCharge? UsageCharge { get; set; }
}

public class UsageChargeList
{
    [JsonPropertyName("usage_charges")]
    public IEnumerable<UsageCharge>? UsageCharges { get; set; }
}
