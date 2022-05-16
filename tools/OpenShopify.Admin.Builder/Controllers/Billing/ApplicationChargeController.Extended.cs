using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationChargeController : IApplicationChargeController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("application_charges.json")]
    [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status200OK)]
    public Task CreateApplicationChargeAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("application_charges.json")]
    [ProducesResponseType(typeof(ApplicationChargeList), StatusCodes.Status200OK)]
    public Task RetrieveListOfApplicationChargesAsync(string? fields, string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("application_charges/{application_charge_id}.json")]
    [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status200OK)]
    public Task RetrieveApplicationChargeAsync(string application_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }
}

public class ApplicationChargeItem
{
    [JsonPropertyName("application_charge")]
    public OpenShopify.Admin.Builder.Models.ApplicationCharge? ApplicationCharge { get; set; }
}

public class ApplicationChargeList
{
    [JsonPropertyName("application_charges")]
    public IEnumerable<OpenShopify.Admin.Builder.Models.ApplicationCharge>? ApplicationCharges { get; set; }
}