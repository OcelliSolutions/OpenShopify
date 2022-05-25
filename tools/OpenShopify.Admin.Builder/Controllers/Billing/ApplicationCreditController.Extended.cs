using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(typeof(ApplicationCreditError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateApplicationCredit([Required] CreateApplicationCreditRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("application_credits.json")]
    [ProducesResponseType(typeof(ApplicationCreditList), StatusCodes.Status200OK)]
    public override Task ListApplicationCredits(string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("application_credits/{application_credit_id:long}.json")]
    [ProducesResponseType(typeof(ApplicationCreditItem), StatusCodes.Status200OK)]
    public override Task GetApplicationCredit([Required] long application_credit_id, string? fields = null)
    {
        throw new NotImplementedException();
    }
}