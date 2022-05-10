using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationCreditController : ApplicationCreditControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public override Task CreateApplicationCredit()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(ApplicationCreditList), StatusCodes.Status200OK)]
    public override Task RetrieveAllApplicationCredits(string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleApplicationCredit(string application_credit_id, string? fields = null)
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