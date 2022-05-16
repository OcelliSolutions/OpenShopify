using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationCreditController : IApplicationCreditController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("application_credits.json")]
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public Task CreateApplicationCreditAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("application_credits.json")]
    [ProducesResponseType(typeof(ApplicationCreditList), StatusCodes.Status200OK)]
    public Task RetrieveAllApplicationCreditsAsync(string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("application_credits/{application_credit_id}.json")]
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public Task RetrieveSingleApplicationCreditAsync(string application_credit_id, string? fields)
    {
        throw new NotImplementedException();
    }
}

public class ApplicationCreditItem
{
    [JsonPropertyName("application_credit")]
    public ApplicationCredit? ApplicationCredit { get; set; }
}

public class ApplicationCreditList
{
    [JsonPropertyName("application_credits")]
    public IEnumerable<ApplicationCredit>? ApplicationCredits { get; set; }
}