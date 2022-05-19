using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationCreditController : ApplicationCreditControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("application_credits.json")]
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status201Created)]
    public override Task CreateApplicationCredit(ApplicationCreditItem request)
    {
        throw new NotImplementedException();
    }
    
    /// <inheritdoc />
    [HttpGet, Route("application_credits.json")]
    [ProducesResponseType(typeof(ApplicationCreditList), StatusCodes.Status200OK)]
    public override Task RetrieveAllApplicationCredits(string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("application_credits/{application_credit_id:long}.json")]
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleApplicationCredit(long application_credit_id, string? fields)
    {
        throw new NotImplementedException();
    }
}