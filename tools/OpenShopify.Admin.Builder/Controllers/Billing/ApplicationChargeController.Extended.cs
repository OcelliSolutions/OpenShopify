using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class ApplicationChargeController : ApplicationChargeControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("application_charges.json")]
    [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status201Created)]
    public override Task CreateApplicationCharge(ApplicationChargeItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("application_charges.json")]
    [ProducesResponseType(typeof(ApplicationChargeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfApplicationCharges(string? fields, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("application_charges/{application_charge_id:long}.json")]
    [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task RetrieveApplicationCharge(long application_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }
}