using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class UsageChargeController : UsageChargeControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}/usage_charges.json")]
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status201Created)]
    public override Task CreateUsageCharge([Required] CreateUsageChargeRequest request,
        [Required] long recurring_application_charge_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}/usage_charges.json")]
    [ProducesResponseType(typeof(UsageChargeList), StatusCodes.Status200OK)]
    public override Task ListUsageCharges([Required] long recurring_application_charge_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route(
        "recurring_application_charges/{recurring_application_charge_id:long}/usage_charges/{usage_charge_id:long}.json")]
    [ProducesResponseType(typeof(UsageChargeItem), StatusCodes.Status200OK)]
    public override Task GetUsageCharge([Required] long recurring_application_charge_id, [Required] long usage_charge_id,
        string? fields = null) => throw new NotImplementedException();
}