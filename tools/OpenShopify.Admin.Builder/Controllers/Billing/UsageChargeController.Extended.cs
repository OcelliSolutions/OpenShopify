using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class UsageChargeController : UsageChargeControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status200OK)]
    public override Task CreateUsageCharge(string recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(UsageChargeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfUsageCharges(string recurring_application_charge_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleCharge(string recurring_application_charge_id, string usage_charge_id, string? fields = null)
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
